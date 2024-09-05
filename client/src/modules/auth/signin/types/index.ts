import { z } from "zod";
import { loginrSchema } from "../schemas/login-schema";

export type loginSchemaType = z.infer<typeof loginrSchema>;
