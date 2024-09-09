import { z } from "zod";
import { linkSchema } from "../schemas";

export type linkSchemaType = z.infer<typeof linkSchema>;
