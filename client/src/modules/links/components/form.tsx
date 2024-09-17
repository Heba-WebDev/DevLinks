"use client";
import { useState } from "react";
import {
  Button,
} from "@/components/ui";
import LetsGetStarted from "./get-started";
import { linkProps } from "../types/index";
import Link from "./link";

export default function LinksForm() {
    const [links, setLinks] = useState<linkProps[]>([]);
    const addLink = () => {
      const link: linkProps = {
        id: null,
        number: links.length + 1,
        platform: "",
        link: "",
      };
      setLinks([...links, link]);
    }

    return (
      <div className="">
        <Button
          onClick={() => addLink()}
          className="mb-6 bg-white w-full border-2 border-purple text-purple"
        >
          + Add new link
        </Button>
        {links && links.length === 0 && <LetsGetStarted />}
        {links && links.length >= 1 && links?.map((link) => {
          return (
            <Link
              id={link.id}
              number={link.number}
              platform={link.platform}
              link={link.link}
              links={links}
              setLinks={setLinks}
            />
          );
        })}
        <div className=" flex flex-col mt-8">
          <hr className="py-1 -mx-6 md:-mx-10" />
          <Button className="text-white bg-purpleHover self-end">Save</Button>
        </div>
      </div>
    );
}