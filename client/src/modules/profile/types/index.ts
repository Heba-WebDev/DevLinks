import { z } from "zod";
import { profileSchema } from "../schemas";

export type profileSchemaType = z.infer<typeof profileSchema>;
