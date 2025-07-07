import { apiFetch } from "@/api/base";

export async function calculateExpression(expression: string): Promise<number> {
  return apiFetch<number>("/calculator/expression", {
    method: "POST",
    body: JSON.stringify({ expression }),
  });
}
