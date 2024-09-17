import { z } from "zod";
import { linkSchema } from "../schemas";

export type linkSchemaType = z.infer<typeof linkSchema>;
export type linkProps = {
    id: string | null,
    number: number,
    platform: string | null,
    link: string | null,
};

export interface LinkComponentProps extends linkProps {
  links: linkProps[];
  setLinks: React.Dispatch<React.SetStateAction<linkProps[]>>;
}
