"use client";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
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
import { IoIosLock, IoIosEyeOff, IoIosEye } from "react-icons/io";
import Spinner from "@/components/shared/spinner";
import { toast } from "react-toastify";
import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { FrontendResetPasswordSchemaType } from "./types";
import { frontendResetPasswordSchema } from "./schemas";
import { resetPassword } from "./actions";

const ResetPasswordForm = () => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const token = searchParams.get("token");
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);
  const form = useForm<FrontendResetPasswordSchemaType>({
    resolver: zodResolver(frontendResetPasswordSchema),
    defaultValues: {
      password: "",
      confirmPassword: ""
    },
  });
  const mutation = useMutation({
    mutationFn: resetPassword,
    onSuccess: (data) => {
      if (data.status === "success") {
        toast.success("Successfully updated the password");
        navigate("/login");
      } else {
        toast.error(data.error);
      }
    },
    onError: () => {
      toast.error("Unexpected error occurred");
    },
  });
  const onSubmit = async (values: FrontendResetPasswordSchemaType) => {
    mutation.mutate({ password: values.password, token: token as string });
  };
  useEffect(() => {
    if (!token) navigate('/');
    if (token && token.split('.').length !== 3) navigate('/');
  }, [token, navigate]);
  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)}>
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
        <FormField
          control={form.control}
          name="confirmPassword"
          render={({ field }) => (
            <FormItem className="pb-6 relative">
              <IoIosLock className="absolute top-[42px] text-gray ml-2 text-lg" />
              <IoIosEyeOff
                onClick={() => setShowConfirmPassword(!showConfirmPassword)}
                className={`${
                  !showConfirmPassword ? "block" : "hidden"
                } absolute text-gray right-0 top-[36.6px] mr-2 hover:cursor-pointer`}
              />
              <IoIosEye
                onClick={() => setShowConfirmPassword(!showConfirmPassword)}
                className={`${
                  showConfirmPassword ? "block" : "hidden"
                } absolute text-gray right-0 top-[36.6px] mr-2 hover:cursor-pointer`}
              />
              <FormLabel>Confirm Password</FormLabel>
              <FormControl>
                <Input
                  placeholder="At least 8 characters"
                  type={showConfirmPassword ? "text" : "password"}
                  className="mt-1 pl-7 focus-visible:ring-0"
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <div className="w-full pt-3">
          <Button variant={"default"} className="w-full hover:bg-purpleHover">
            {mutation.isPending ? <Spinner /> : "Reset Password"}
          </Button>
        </div>
      </form>
    </Form>
  );
};

export default ResetPasswordForm;
