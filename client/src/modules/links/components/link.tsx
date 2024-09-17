"use client";
import {
  Button,
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
  FormLabel,
  FormItem,
  FormControl,
  Input,
  FormMessage,
  Form
} from "@/components/ui";
import { useForm } from "react-hook-form";
import { LinkComponentProps, linkSchemaType } from "../types";
import { zodResolver } from "@hookform/resolvers/zod";
import { linkSchema } from "../schemas";
import { RiEqualLine } from "react-icons/ri";
import { FaLink, FaGithub, FaYoutube, FaFacebook } from "react-icons/fa";


export default function Link(
  { id, number, platform, link, links, setLinks }: LinkComponentProps
) {
  const form = useForm<linkSchemaType>({
    resolver: zodResolver(linkSchema),
    defaultValues: {
      id,
      platform,
      link: link as string,
    },
  });
  const removeLink = (number: number) => {
    const newLinks = links.filter((link) => link.number !== number);
    setLinks(newLinks);
  }
  return (
    <>
      <Form {...form}>
        <form
          onSubmit={() => {}}
          className="bg-grayLight p-5 rounded-lg flex flex-col gap-2 mb-6"
        >
          <div className=" flex justify-between items-center text-base">
            <div className="text-gray font-semibold flex items-center gap-1">
              <RiEqualLine />
              <h3>Link #{number}</h3>
            </div>
            <Button onClick={() => removeLink(number)} className="bg-transparent hover:bg-transparent text-gray px-0 text-base font-extralight">
              Remove
            </Button>
          </div>
          <FormItem className="pb-1 relative">
            <FormLabel>Platform</FormLabel>
            <Select>
              <SelectTrigger className="">
                <SelectValue placeholder="" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="light">
                  <div className="flex items-center gap-1 text-gray hover:text-purple">
                    <FaGithub className="text-lg" />
                    <p>Github</p>
                  </div>
                </SelectItem>
                <SelectItem value="dark">
                  <div className="flex items-center gap-1 text-gray hover:text-purple">
                    <FaYoutube className="text-lg" />
                    <p>Youtube</p>
                  </div>
                </SelectItem>

                <SelectItem value="system">
                  <div className="flex items-center gap-1 text-gray hover:text-purple">
                    <FaFacebook className="text-lg" />
                    <p>Facenbook</p>
                  </div>
                </SelectItem>
              </SelectContent>
            </Select>
          </FormItem>
          <FormItem className="pb-1 relative">
            <FormLabel>Link</FormLabel>
            <FaLink className=" absolute top-[38px] text-gray ml-2 text-sm" />
            <FormControl>
              <Input
                placeholder="https://www.example.com/user2536"
                className="mt-1 pl-7 focus-visible:ring-0"
              />
            </FormControl>
            <FormMessage />
          </FormItem>
        </form>
      </Form>
    </>
  );
}
