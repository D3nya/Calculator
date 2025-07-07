import React from "react";
import { Link } from "react-router";
import { Button } from "@/components/ui/button";
import { ROUTES } from "@/config/routes";

type Props = { children: React.ReactNode };

type State = { hasError: boolean };

export class ErrorBoundary extends React.Component<Props, State> {
  state: State = { hasError: false };

  static getDerivedStateFromError() {
    return { hasError: true };
  }

  componentDidCatch(error: unknown) {
    console.error("Error caught in ErrorBoundary:", error);
  }

  render() {
    if (this.state.hasError) {
      return (
        <section className="flex flex-1 flex-col items-center justify-center bg-background px-4 sm:px-6 lg:px-8">
          <div className="mx-auto max-w-md text-center">
            <h1 className="mt-4 text-3xl font-bold tracking-tight text-foreground sm:text-4xl">
              Oops, something went wrong!
            </h1>
            <p className="mt-4 text-muted-foreground">
              We're sorry, but an unexpected error has occurred. Please try again later or contact support if the issue
              persists.
            </p>
            <div className="mt-6">
              <Button
                asChild
                className="inline-flex h-10 items-center rounded-md bg-gray-900 px-8 text-sm font-medium text-gray-50 shadow transition-colors hover:bg-gray-900/90 focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-gray-950 disabled:pointer-events-none disabled:opacity-50 dark:bg-gray-50 dark:text-gray-900 dark:hover:bg-gray-50/90 dark:focus-visible:ring-gray-300"
              >
                <Link to={ROUTES.appRoute}>Go to Homepage</Link>
              </Button>
            </div>
          </div>
        </section>
      );
    }

    return this.props.children;
  }
}
