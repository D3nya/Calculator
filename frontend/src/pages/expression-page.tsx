import { calculateExpression } from "@/api/calculateExpression";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useMutation } from "@tanstack/react-query";
import React, { useState } from "react";

export const ExpressionPage: React.FC = () => {
  const [expression, setExpression] = useState("");

  const mutation = useMutation<number, Error, string>({
    mutationFn: calculateExpression,
  });

  const handleSubmit = () => {
    if (!expression.trim()) return;
    mutation.mutate(expression);
  };

  return (
    <section className="flex flex-1 justify-center items-center">
      <Card className="w-full max-w-md">
        <CardHeader>
          <CardTitle>Expression calculator</CardTitle>
          <CardDescription>Card Description</CardDescription>
        </CardHeader>
        <CardContent className="space-y-4">
          <Label htmlFor="expression">Enter expression</Label>
          <Input
            id="expression"
            value={expression}
            onChange={(e) => setExpression(e.target.value)}
            placeholder="Example: 5 + 2 * (3 ^ 2)"
          />

          {mutation.isSuccess !== null && (
            <div className="text-center text-green-600 font-semibold">Result: {mutation.data}</div>
          )}
          {mutation.isError && <div className="text-center text-red-600 font-semibold">{mutation.error.message}</div>}
        </CardContent>
        <CardFooter>
          <Button onClick={handleSubmit} disabled={mutation.isPending} className="w-full">
            {mutation.isPending ? "Calculating..." : "Calculate"}
          </Button>
        </CardFooter>
      </Card>
    </section>
  );
};
