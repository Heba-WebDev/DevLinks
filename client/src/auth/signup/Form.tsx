"use client";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  Input,
  Button,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../../components/ui/index";
import Spinner from "@/components/shared/spinner";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { PiEnvelopeSimpleFill } from "react-icons/pi";
import { IoIosLock, IoIosEyeOff, IoIosEye } from "react-icons/io";
import { FaUser } from "react-icons/fa";
import { registerSchemaType } from "./types";
import { registerSchema } from "./schemas/register-schema";
import { registerUser } from "./actions";
import { useMutation } from "@tanstack/react-query";

const RegisterForm = () => {
    const navigate = useNavigate();
    const [showPassword, setShowPassword] = useState(false);
    const form = useForm<registerSchemaType>({
      resolver: zodResolver(registerSchema),
      defaultValues: {
        username: "",
        email: "",
        password: "",
      },
    });
    const mutation = useMutation({
      mutationFn: registerUser,
      onSuccess: (data) => {
        if (data.status === "success") {
          toast.success("Successfully registered");
          navigate("/login");
        } else {
          toast.error(data.error);
        }
      },
      onError: () => {
        toast.error("Unexpected error occurred");
      }
    });
    const onSubmit = async (values: registerSchemaType) => {
      mutation.mutate(values);
    };
    return (
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)}>
          <FormField
            control={form.control}
            name="username"
            render={({ field }) => (
              <FormItem className="pb-6 relative">
                <FormLabel>Username</FormLabel>
                <FaUser className=" absolute top-[35px] text-gray ml-2 text-[16px]" />
                <FormControl>
                  <Input
                    placeholder="max23"
                    className="mt-1 pl-7 focus-visible:ring-0"
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem className="pb-6 relative">
                <FormLabel>Email address</FormLabel>
                <PiEnvelopeSimpleFill className=" absolute top-[36px] text-gray ml-2 text-lg" />
                <FormControl>
                  <Input
                    placeholder="e.g john@gmail.com"
                    className=" mt-1 pl-7 focus-visible:ring-0"
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="password"
            render={({ field }) => (
              <FormItem className="pb-6 relative">
                <FormLabel>Password</FormLabel>
                <IoIosLock className="absolute top-[34.5px] text-gray ml-2 text-lg" />
                <IoIosEyeOff
                  onClick={() => setShowPassword(!showPassword)}
                  className={`${
                    !showPassword ? "block" : "hidden"
                  } absolute text-gray right-0 top-[36.6px] mr-2 hover:cursor-pointer`}
                />
                <IoIosEye
                  onClick={() => setShowPassword(!showPassword)}
                  className={`${
                    showPassword ? "block" : "hidden"
                  } absolute text-gray right-0 top-[36.6px] mr-2 hover:cursor-pointer`}
                />
                <FormControl>
                  <Input
                    placeholder="at least 8 characters"
                    type={showPassword ? "text" : "password"}
                    className="mt-1 pl-7 focus-visible:ring-0"
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <div className="w-full pt-3">
            <Button variant={"default"} className="w-full">
              {mutation.isPending ? <Spinner /> : "Create new account" }
            </Button>
          </div>
        </form>
      </Form>
    );
}

export default RegisterForm;