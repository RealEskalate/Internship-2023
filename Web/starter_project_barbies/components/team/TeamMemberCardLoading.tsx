import React, {ReactNode} from "react";
import {BsEmojiSmileUpsideDown, BsFacebook, BsInstagram, BsLinkedin,} from "react-icons/bs";
import Image from "next/image";
import {TeamMember} from "@/types/team";

export type TeamMemberCardProps = {
    teamMember: TeamMember;
};

const socialMediaIcon: { [index: string]: ReactNode } = {
    facebook: <BsFacebook className="fill-gray-400 w-6 h-6"/>,
    linkedin: <BsLinkedin className="fill-gray-400 w-6 h-6"/>,
    instagram: <BsInstagram className="fill-gray-400 w-6 h-6"/>,
    default: <BsEmojiSmileUpsideDown className="fill-gray-400 w-6 h-6"/>,
};

const TeamMemberCardLoading: React.FC<TeamMemberCardProps> = ({
                                                           teamMember: {
                                                               name,
                                                               jobTitle,
                                                               description,
                                                               profileImg,
                                                               socialMediaLinks
                                                           },
                                                       }: TeamMemberCardProps) => {
    const [loaded, setLoaded] = React.useState(false);

    const handleImageLoad = () => {
        setLoaded(true);
    };

    return (
        <div className="box-content font-sans w-72 mt-4 text-center shadow-md shadow-gray-200 rounded-md py-2 m-auto">
            {!loaded && (
                <div className="h-72 w-72 mx-auto bg-gray-200 animate-pulse"/>
            )}

            <div className={loaded ? "block" : "hidden"}>
                <div className="container overflow-hidden my-4">
                    <Image
                        className="rounded-full mx-auto w-32"
                        width={200}
                        height={200}
                        src={profileImg}
                        alt={name}
                        onLoad={handleImageLoad}
                    />
                </div>

                <div className="m-4">
                    <h3 className="text-2xl m-3 font-extrabold tracking-widest uppercase">
                        {name}
                    </h3>
                    <p className="m-3 tracking-widest text-base uppercase">
                        {jobTitle}
                    </p>
                    <p className="text-sm mt-5 mb-3 text-secondarytext font-light px-4 tracking-wide">
                        {description}
                    </p>
                </div>

                <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-50 block m-auto w-5/6"/>

                <div className="flex-row mt-3">
                    {socialMediaLinks &&
                        socialMediaLinks.map(({type, url}, index) => (
                            <div key={index} className="inline-block w-1/3">
                                <a
                                    className="inline-block"
                                    href={url}
                                    target="_blank"
                                    rel="noreferrer"
                                >
                                    {socialMediaIcon[type] || socialMediaIcon["default"]}
                                </a>
                            </div>
                        ))}
                </div>
            </div>
        </div>
    );
};

export default TeamMemberCardLoading;