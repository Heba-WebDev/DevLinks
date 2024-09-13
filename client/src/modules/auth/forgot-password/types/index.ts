import { z } from "zod";
import { forgotPasswordSchema } from "../schemas";

export type forgotPasswordSchemaType = z.infer<typeof forgotPasswordSchema>;
