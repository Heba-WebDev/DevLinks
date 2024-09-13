import { z } from "zod";
import { frontendResetPasswordSchema, resetPasswordSchema } from "../schemas";

export type resetPasswordSchemaType = z.infer<typeof resetPasswordSchema>;
export type FrontendResetPasswordSchemaType = z.infer<typeof frontendResetPasswordSchema>;
