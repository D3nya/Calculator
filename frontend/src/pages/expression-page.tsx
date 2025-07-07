import { calculateExpression } from "@/api/calculateExpression";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Skeleton } from "@/components/ui/skeleton";
import { useMutation } from "@tanstack/react-query";
import { Loader2Icon } from "lucide-react";
import React from "react";

export const ExpressionPage: React.FC = () => {
  const [expression, setExpression] = React.useState("");

  const mutation = useMutation<number, Error, string>({
    mutationFn: calculateExpression,
  });

  const handleSubmit = () => {
    if (!expression.trim()) return;
    mutation.mutate(expression);
  };

  return (
    <section className="flex flex-1 flex-col gap-y-2 xl:gap-y-4 justify-start items-center">
      <Card className="w-full max-w-md md:max-w-xl lg:max-w-2xl xl:max-w-4xl">
        <CardHeader>
          <CardTitle>Expression Calculator</CardTitle>
          <CardDescription className="mt-2">
            Supports:
            <ul className="my-6 ml-6 list-disc [&>li]:mt-2">
              <li>
                Digits{" "}
                <code className="bg-muted relative rounded px-[0.3rem] py-[0.2rem] font-mono text-sm font-semibold">
                  0 - 9
                </code>
              </li>
              <li>
                Operators{" "}
                <code className="bg-muted relative rounded px-[0.3rem] py-[0.2rem] font-mono text-sm font-semibold">
                  +, -, *, /, %, **
                </code>
              </li>
              <li>
                Brackets{" "}
                <code className="bg-muted relative rounded px-[0.3rem] py-[0.2rem] font-mono text-sm font-semibold">
                  ()
                </code>
              </li>
              <li>
                Functions{" "}
                <code className="bg-muted relative rounded px-[0.3rem] py-[0.2rem] font-mono text-sm font-semibold">
                  sqrt, abs, cos, sin, tan, ln, log, pow, exp
                </code>
              </li>
            </ul>
          </CardDescription>
        </CardHeader>

        <CardContent className="space-y-4">
          <Label htmlFor="expression">Enter expression</Label>
          <Input
            id="expression"
            value={expression}
            onChange={(e) => setExpression(e.target.value)}
            placeholder="Example: sqrt(16) + 2 * (3 ** 2)"
          />
        </CardContent>

        <CardFooter>
          <Button onClick={handleSubmit} disabled={mutation.isPending} className="w-full">
            {mutation.isPending && <Loader2Icon className="animate-spin" />}
            {mutation.isPending ? "Calculating..." : "Calculate"}
          </Button>
        </CardFooter>
      </Card>

      <Card className="w-full max-w-md md:max-w-xl lg:max-w-2xl xl:max-w-4xl">
        <CardHeader>
          <CardTitle>Result</CardTitle>
          <CardDescription>Displays result or error</CardDescription>
        </CardHeader>

        <CardContent className="space-y-4">
          {mutation.isPending && (
            <div className="flex justify-center">
              <Skeleton className="h-8 w-40 rounded-md" />
            </div>
          )}
          {mutation.isSuccess && (
            <p className="leading-7 text-center font-semibold text-green-600">Result: {mutation.data.toFixed(4)}</p>
          )}
          {mutation.isError && (
            <p className="leading-7 text-center font-semibold text-red-600">{mutation.error.message}</p>
          )}
        </CardContent>
      </Card>
    </section>
  );
};
