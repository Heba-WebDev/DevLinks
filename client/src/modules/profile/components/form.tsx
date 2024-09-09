"use client";
import {
  Button,
  FormLabel,
  FormItem,
  FormControl,
  Input,
  FormMessage,
  Label
} from "@/components/ui";
import { CiImageOn } from "react-icons/ci";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Form } from "@/components/ui";
import { profileSchemaType } from "../types";
import { profileSchema } from "../schemas";

export default function ProfileForm() {
  const form = useForm<profileSchemaType>({
    resolver: zodResolver(profileSchema),
    defaultValues: {
      image: undefined,
      firstName: "",
      lastName: "",
      email: ""
    },
  });
  return (
    <div className="">
      <Form {...form}>
        <form onSubmit={() => {}} className=" grid gap-6">
          <div className="bg-grayLight p-5 rounded-lg flex flex-col gap-5 md:gap-2">
            <FormItem className="flex flex-col md:flex-row gap-4 md:gap-0 md:justify-around items-center">
              <FormLabel className="w-full text-gray">
                Profile Picture
              </FormLabel>
              <FormControl>
                <div className="relative flex flex-col md:flex-row w-full gap-5 items-center">
                  <Input
                    type="file"
                    className="relative w-52 h-40 md:w-48 md:h-48 py-3 px-4 hover:cursor-pointer bg-purpleLight border-0 self-start md:self-auto text-transparent"
                  />
                  <CiImageOn className="absolute top-[60px] left-[90px] md:left-[80px] font-bold text-purple text-3xl md:text-4xl" />
                  <p className="absolute top-[100px] left-[55px] md:left-[40px] text-purple text-sm lg:text-base font-semibold">
                    + Upload Image
                  </p>
                  <Label className="text-gray text-sm font-extralight self-start md:self-auto">
                    Image must be below 5MB
                  </Label>
                </div>
              </FormControl>
              <FormMessage />
            </FormItem>
          </div>
          <div className="bg-grayLight p-5 rounded-lg flex flex-col gap-5 md:gap-2">
            <FormItem className="grid md:flex md:justify-around items-center">
              <FormLabel className="w-full text-gray">First Name</FormLabel>
              <FormControl>
                <Input placeholder="eg. John" className="py-3 px-4" />
              </FormControl>
              <FormMessage />
            </FormItem>

            <FormItem className="grid md:flex md:justify-around items-center">
              <FormLabel className="w-full text-gray">Last Name</FormLabel>
              <FormControl>
                <Input placeholder="eg. Doe" className="py-3 px-4" />
              </FormControl>
              <FormMessage />
            </FormItem>

            <FormItem className="grid md:flex md:justify-around items-center">
              <FormLabel className="w-full text-gray">Email</FormLabel>
              <FormControl>
                <Input
                  placeholder="eg. john@example.com"
                  className="py-3 px-4 w-full"
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          </div>
        </form>
      </Form>
      <div className=" flex flex-col mt-8">
        <hr className="py-1 -mx-6 md:-mx-10" />
        <Button className="text-white bg-purpleHover self-end">Save</Button>
      </div>
    </div>
  );
}
