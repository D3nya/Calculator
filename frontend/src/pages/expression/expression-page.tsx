import { calculateExpression } from "@/api/calculateExpression";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Skeleton } from "@/components/ui/skeleton";
import { useMutation } from "@tanstack/react-query";
import { Loader2Icon } from "lucide-react";
import React from "react";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Form, FormControl, FormDescription, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { FormSchema } from "./zod-schema";

const CardDescriptionItems = [
  { title: "Digits", code: "0 - 9" },
  { title: "Operators", code: "+, -, *, /, %, **" },
  { title: "Brackets", code: "()" },
  { title: "Functions", code: "sqrt, abs, cos, sin, tan, ln, log, pow, exp" },
  { title: "Commas", code: "," },
];

export const ExpressionPage: React.FC = () => {
  const mutation = useMutation<number, Error, string>({
    mutationFn: calculateExpression,
  });

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      expression: "",
    },
  });

  function onSubmit(values: z.infer<typeof FormSchema>) {
    mutation.mutate(values.expression);
  }

  return (
    <section className="flex flex-1 flex-col gap-y-2 xl:gap-y-4 justify-start items-center">
      <Card className="w-full max-w-md md:max-w-xl lg:max-w-2xl xl:max-w-4xl">
        <CardHeader>
          <CardTitle>Expression Calculator</CardTitle>
          <CardDescription className="mt-2">
            Supports:
            <ul className="my-6 ml-6 list-disc [&>li]:mt-2">
              {CardDescriptionItems.map((item) => (
                <li key={item.title}>
                  {item.title}{" "}
                  <code className="bg-muted relative rounded px-[0.3rem] py-[0.2rem] font-mono text-sm font-semibold">
                    {item.code}
                  </code>
                </li>
              ))}
            </ul>
          </CardDescription>
        </CardHeader>

        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
            <CardContent className="space-y-4">
              <FormField
                control={form.control}
                name="expression"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Enter expression</FormLabel>
                    <FormControl>
                      <Input placeholder="Example: sqrt(16) + 2 * (3 ** 2)" {...field} />
                    </FormControl>
                    <FormDescription>This is your expression, which will be calculated.</FormDescription>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </CardContent>

            <CardFooter className="flex-col gap-2">
              <Button type="submit" disabled={mutation.isPending} className="w-full">
                {mutation.isPending && <Loader2Icon className="animate-spin" />}
                {mutation.isPending ? "Calculating..." : "Calculate"}
              </Button>
              <Button type="button" variant="outline" className="w-full" onClick={() => form.reset()}>
                Reset
              </Button>
            </CardFooter>
          </form>
        </Form>
      </Card>

      <Card className="w-full min-h-40 max-w-md md:max-w-xl lg:max-w-2xl xl:max-w-4xl">
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
