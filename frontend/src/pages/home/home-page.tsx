import React from "react";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { Mode } from "./mode";

const HomePage: React.FC = () => {
  return (
    <section className="flex flex-1 flex-col items-center justify-start px-4 py-12 space-y-8 max-w-4xl mx-auto">
      <Card>
        <CardHeader>
          <CardTitle className="text-3xl">🧠 Calculator</CardTitle>
          <CardDescription className="text-base mt-2">
            This is not just a basic calculator — it’s a structured API-powered calculator with multiple modes and
            advanced expression support.
          </CardDescription>
        </CardHeader>
        <CardContent className="space-y-4 text-muted-foreground text-sm leading-6">
          <p>
            The calculator exposes a set of API endpoints to perform simple and complex mathematical operations.
            Additionally, it handles expression parsing, operator precedence, and provides clear error messages for
            invalid inputs.
          </p>
          <p>
            This application is designed with scalability and maintainability in mind — service-oriented structure,
            request validation, error handling, and a modern React + shadcn/ui frontend.
          </p>
        </CardContent>
      </Card>

      <Card>
        <CardHeader>
          <CardTitle className="text-2xl">🧩 Supported Modes</CardTitle>
          <CardDescription>Each mode corresponds to a dedicated API endpoint with isolated logic.</CardDescription>
        </CardHeader>
        <CardContent className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 text-sm text-muted-foreground">
          <Mode name="Sum" description="Adds two numbers" />
          <Mode name="Subtract" description="Subtracts second number from the first" />
          <Mode name="Multiply" description="Multiplies two numbers" />
          <Mode name="Divide" description="Divides the first number by the second" />
          <Mode name="Power" description="Raises a number to the given power" />
          <Mode name="Root" description="Calculates the root of a number given the base" />
          <Mode name="Expression" description="Evaluates complex expressions like 5 + 4 * sqrt(16)" />
        </CardContent>
      </Card>

      <Separator />
      <p className="text-sm text-muted-foreground text-center max-w-xl">
        Imagine this calculator as a foundation for any compute-heavy API. The same architecture could serve scientific
        computation, statistics, or business logic. Filters, validation, exception handling, and modular design are all
        in place.
      </p>
    </section>
  );
};

export default HomePage;
