import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import React, { useState } from "react";

export const ExpressionPage: React.FC = () => {
  const [expression, setExpression] = useState("");
  const [result, setResult] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const handleCalculate = async () => {
    if (!expression.trim()) {
      setError("Enter an expression to calculate");
      setResult(null);
      return;
    }

    setLoading(true);
    setError(null);
    setResult(null);

    try {
      const res = await fetch("http://localhost:5280/calculator/expression", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ expression }),
      });

      if (!res.ok) {
        const { message } = await res.json();
        throw new Error(message || "Error calculating expression");
      }

      const data = await res.json();
      setResult(data);
    } catch (e: unknown) {
      if (e instanceof Error) {
        setError(e.message);
      } else {
        setError("An unexpected error occurred");
      }
    } finally {
      setLoading(false);
    }
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

          {result !== null && <div className="text-center text-green-600 font-semibold">Result: {result}</div>}
          {error && <div className="text-center text-red-600 font-semibold">{error}</div>}
        </CardContent>
        <CardFooter>
          <Button onClick={handleCalculate} disabled={loading} className="w-full">
            {loading ? "Calculating..." : "Calculate"}
          </Button>
        </CardFooter>
      </Card>
    </section>
  );
};
