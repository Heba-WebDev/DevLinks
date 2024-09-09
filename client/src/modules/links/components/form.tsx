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
} from "@/components/ui";
// import LetsGetStarted from "./get-started";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { linkSchema } from "../schemas";
import { linkSchemaType } from "../types/index";
import { Form } from "@/components/ui";
import { RiEqualLine } from "react-icons/ri";
import { FaLink, FaGithub, FaYoutube, FaFacebook } from "react-icons/fa";

export default function LinksForm() {
    const form = useForm<linkSchemaType>({
      resolver: zodResolver(linkSchema),
      defaultValues: {
        link: "",
      }
    });
    return (
      <div className="">
        <Button className="mb-6 bg-white w-full border-2 border-purple text-purple">
          + Add new link
        </Button>
        {/* <LetsGetStarted /> */}
        <Form {...form}>
          <form
            onSubmit={() => {}}
            className="bg-grayLight p-5 rounded-lg flex flex-col gap-2"
          >
            <div className=" flex justify-between items-center text-base">
              <div className="text-gray font-semibold flex items-center gap-1">
                <RiEqualLine />
                <h3>Link #1</h3>
              </div>
              <Button className="bg-transparent hover:bg-transparent text-gray px-0 text-base font-extralight">
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
        <div className=" flex flex-col mt-8">
          <hr className="py-1 -mx-6 md:-mx-10" />
          <Button className="text-white bg-purpleHover self-end">Save</Button>
        </div>
      </div>
    );
}