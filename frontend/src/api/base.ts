const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export async function apiFetch<T>(endpoint: string, options?: RequestInit): Promise<T> {
  const res = await fetch(`${API_BASE_URL}${endpoint}`, {
    headers: { "Content-Type": "application/json" },
    ...options,
  });

  if (!res.ok) {
    const { message } = await res.json().catch(() => ({}));
    throw new Error(message || `API Error: ${res.status}`);
  }

  return res.json();
}
