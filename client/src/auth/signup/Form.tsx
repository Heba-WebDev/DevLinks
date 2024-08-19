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
import { registerSchemaType } from "./types";
import { registerSchema } from "./schemas/register-schema";
import { registerUser } from "./actions";

const RegisterForm = () => {
    const form = useForm<registerSchemaType>({
      resolver: zodResolver(registerSchema),
      defaultValues: {
        username: "",
        email: "",
        password: "",
      },
    });
    const onSubmit = async (values: registerSchemaType) => {
      const response = await registerUser(values);
      console.log(response);
    };
    return (
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)}>
          <FormField
            control={form.control}
            name="username"
            render={({ field }) => (
              <FormItem className="pb-6">
                <FormLabel>Username</FormLabel>
                <FormControl>
                  <Input
                    placeholder="Max23"
                    className=" mt-1 focus-visible:ring-0"
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
              <FormItem className="pb-6">
                <FormLabel>Email address</FormLabel>
                <FormControl>
                  <Input
                    placeholder="e.g john@gmail.com"
                    className=" mt-1 focus-visible:ring-0"
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
              <FormItem className="pb-6">
                <FormLabel>Password</FormLabel>
                <FormControl>
                  <Input
                    placeholder="At least 8 characters"
                    className=" mt-1 focus-visible:ring-0"
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <div className="w-full pt-3">
            <Button variant={"default"} className="w-full">
              Create new account
            </Button>
          </div>
        </form>
      </Form>
    );
}

export default RegisterForm;