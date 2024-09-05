import { z } from "zod";
import { registerSchema } from "../schemas/register-schema";

export type registerSchemaType = z.infer<typeof registerSchema>;
