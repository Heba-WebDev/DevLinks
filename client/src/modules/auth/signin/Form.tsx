"use client";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  Form,
  Input,
  Button,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui";
import { PiEnvelopeSimpleFill } from "react-icons/pi";
import { IoIosLock, IoIosEyeOff, IoIosEye } from "react-icons/io";
import Spinner from "@/components/shared/spinner";
import { toast } from "react-toastify";
import { useMutation } from "@tanstack/react-query";
import { loginSchemaType } from "./types";
import { loginrSchema } from "./schemas/login-schema";
import { loginUser } from "./actions";
import { useAppDispatch } from "@/hooks/store";
import { login } from "@/store/user/user-slice";
import { Link, useNavigate } from "react-router-dom";

const LoginForm = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const [showPassword, setShowPassword] = useState(false);
  const form = useForm<loginSchemaType>({
    resolver: zodResolver(loginrSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });
  const mutation = useMutation({
    mutationFn: loginUser,
    onSuccess: (data) => {
      if (data.status === "success") {
        toast.success("Successfully logged in");
        dispatch(login({accessToken: data.data.accessToken, ...data.data.user}));
        navigate("/");
      } else {
        toast.error(data.error);
      }
    },
    onError: () => {
      toast.error("Unexpected error occurred");
    },
  });
  const onSubmit = async (values: loginSchemaType) => {
    mutation.mutate(values);
  };
  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)}>
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
          name="password"
          render={({ field }) => (
            <FormItem className="pb-6 relative">
              <IoIosLock className="absolute top-[42px] text-gray ml-2 text-lg" />
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
              <FormLabel>Password</FormLabel>
              <FormControl>
                <Input
                  placeholder="At least 8 characters"
                  type={showPassword ? "text" : "password"}
                  className="mt-1 pl-7 focus-visible:ring-0"
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <div className="-mt-3 flex justify-end w-full">
          <Link to="/forgot-password" className="text-sm text-right text-gray">
            Forgot password?
          </Link>
        </div>
        <div className="w-full pt-3">
          <Button variant={"default"} className="w-full hover:bg-purpleHover">
            {mutation.isPending ? <Spinner /> : "Login"}
          </Button>
        </div>
      </form>
    </Form>
  );
};

export default LoginForm;
