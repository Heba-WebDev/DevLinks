import { z } from "zod";

export const resetPasswordSchema = z.object({
    password:
    z.string()
    .min(8, {message: "A password must be at least 8 characters long"})
    .max(25, {message: "A password must be less than 25 characters"})
    .regex(/^[a-zA-Z\d_-]{8,}$/, {
      message: "Password can only contain letters, digits, _, and -",
    }),
    token: z.string()
});

export const frontendResetPasswordSchema = z.object({
  password: z
    .string()
    .min(8, { message: "A password must be at least 8 characters long" })
    .max(25, { message: "A password must be less than 25 characters" })
    .regex(/^[a-zA-Z\d_-]{8,}$/, {
      message: "Password can only contain letters, digits, _, and -",
    }),
  confirmPassword: z
    .string()
    .min(8, { message: "A password must be at least 8 characters long" })
    .max(25, { message: "A password must be less than 25 characters" })
    .regex(/^[a-zA-Z\d_-]{8,}$/, {
      message: "Password can only contain letters, digits, _, and -",
    }),
}).refine(
  (values) => values.password === values.confirmPassword,
  {
    message: "Password and Confirm Password must match",
    path: ["confirmPassword"],
  }
);

