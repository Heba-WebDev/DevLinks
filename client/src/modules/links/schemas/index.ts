import { z } from "zod";

export const linkSchema = z.object({
    id: z.string().nullable(),
    platform: z.string().nullable(),
    link: z.string().url({message: "A valid link is required"}),
});
