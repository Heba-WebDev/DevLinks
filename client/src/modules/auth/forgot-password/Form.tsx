"use client";
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
import Spinner from "@/components/shared/spinner";
import { toast } from "react-toastify";
import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { forgotPasswordSchemaType } from "./types";
import { forgotPasswordSchema } from "./schemas";
import { forgotPassword } from "./actions";

const ForgotPasswordForm = () => {
  const navigate = useNavigate();
  const form = useForm<forgotPasswordSchemaType>({
    resolver: zodResolver(forgotPasswordSchema),
    defaultValues: {
      email: "",
    },
  });
  const mutation = useMutation({
    mutationFn: forgotPassword,
    onSuccess: (data) => {
      if (data.status === "success") {
        toast.success(data.message ?? "An email has been sent");
        navigate("/");
      } else {
        toast.error(data.error);
      }
    },
    onError: () => {
      toast.error("Unexpected error occurred");
    },
  });
  const onSubmit = async (values: forgotPasswordSchemaType) => {
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
        <div className="w-full pt-3">
          <Button variant={"default"} className="w-full hover:bg-purpleHover">
            {mutation.isPending ? <Spinner /> : "Send"}
          </Button>
        </div>
      </form>
    </Form>
  );
};

export default ForgotPasswordForm;
