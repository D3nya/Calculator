import z from "zod";

const VALID_EXPRESSION_REGEX = /^([0-9+\-*/%().,\s]|\*\*|sqrt|abs|cos|sin|tan|ln|log|pow|exp)+$/;

export const FormSchema = z.object({
  expression: z
    .string()
    .nonempty({
      message: "Expression cannot be empty",
    })
    .max(200, {
      message: "Expression must not exceed 200 characters",
    })
    .regex(VALID_EXPRESSION_REGEX, {
      message:
        "Only digits, + - * / % **, parentheses, spaces, commas, and functions (sqrt, abs, cos, sin, tan, ln, log, pow, exp) are allowed",
    }),
});
