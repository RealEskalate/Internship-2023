import React from 'react';
import heroImage from '../../public/image/team/hero-image.svg';
import Image from 'next/image';
import TeamMemberCard from '@/components/team/TeamMemberCard';
import {useGetTeamMembersQuery} from "@/store/team/team-api";
export const TeamPage: React.FC = () => {
    const { data, isLoading, error } = useGetTeamMembersQuery();

    return (
        <div className="px-12 my-8 md:px-20 lg:px-28">
            <div className="flex flex-col md:flex-row">
                <div className="w-full md:w-2/5">
                    <h1 className="text-5xl text-secondarytext font-extrabold lg:leading-snug my-8 md:text-3xl lg:text-5xl">
                        THE TEAM WE&apos;RE CURRENTLY WORKING WITH
                    </h1>
                    <p className="text-base md:text-sm lg:text-base lg:leading-7 text-secondarytext font-light">
                        Meet our development team is a small but highly skilled and
                        experienced group of professionals. We have a talented mix of web
                        developers, software engineers, project managers and quality
                        assurance specialists who are passionate about developing
                        exceptional products and services.
                    </p>
                </div>
                <div className="w-0 md:w-3/5 my-8">
                    <Image src={heroImage} alt="placeholder" />
                </div>
            </div>

            <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-100 block w-5/6 my-8 m-auto" />

            {
                isLoading && <div>Loading...</div>
            }

            {
                error && <div>Error occurred processing your request</div>
            }

            {
                data && <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
                    {data?.map((data, index) => (
                        <TeamMemberCard key={index} teamMember={data} />
                    ))}
                </div>
            }

        </div>
    );
};

export default TeamPage;