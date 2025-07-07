import { SidebarInset, SidebarProvider } from "@/components/ui/sidebar";
import { AppSidebar } from "@/components/app-sidebar";
import { ThemeProvider } from "@/components/theme/theme-provider";
import { Header } from "@/components/header/header";
import { Outlet } from "react-router";
import { Suspense } from "react";
import { Spinner } from "@/components/ui/spinner";
import { ErrorBoundary } from "@/components/error-boundary";

export default function Layout() {
  return (
    <ThemeProvider>
      <SidebarProvider>
        <AppSidebar />
        <SidebarInset>
          <Header />
          <main className="flex flex-1 flex-col gap-4 p-4">
            <Suspense
              fallback={
                <div className="flex flex-1 items-center justify-center">
                  <Spinner size="large" />
                </div>
              }
            >
              <ErrorBoundary>
                <Outlet />
              </ErrorBoundary>
            </Suspense>
          </main>
        </SidebarInset>
      </SidebarProvider>
    </ThemeProvider>
  );
}
