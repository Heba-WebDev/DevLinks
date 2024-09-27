"use client";
import { useEffect, useState } from "react";
import {
  Button,
} from "@/components/ui";
import LetsGetStarted from "./get-started";
import { linkProps } from "../types/index";
import Link from "./link";
import { useAppDispatch, useAppSelector } from "@/hooks/store";
import { getLinks } from "@/store/links/links-slice";
import { useQuery } from "@tanstack/react-query";
import { fetchLinks } from "../actions";

export default function LinksForm() {
    const dispatch = useAppDispatch();
    const user = useAppSelector((state) => state.user);
    // const savedLinks = useAppSelector((state) => state.links);
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
    const { isFetched, data } = useQuery({
      queryKey: ["links"],
      queryFn: () => fetchLinks(user.accessToken!),
      enabled: !!user.accessToken,
      staleTime: 5 * 60 * 1000,
      refetchOnWindowFocus: false,
      refetchOnMount: false,
    });
    useEffect(() => {
      if (isFetched) dispatch(getLinks(data?.data?.links))
    }, [isFetched, dispatch, data]);
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