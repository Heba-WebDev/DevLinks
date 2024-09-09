import { z } from "zod";

export const linkSchema = z.object({
    link: z.string().url({message: "A valid link is required"}),
});
