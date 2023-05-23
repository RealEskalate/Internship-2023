import Image from "next/image";
import Link from "next/link";
import { IconType } from "react-icons";
import {
  AiFillLinkedin,
  AiFillYoutube,
  AiOutlineInstagram,
  AiOutlineTwitter,
} from "react-icons/ai";
import { MdCopyright, MdOutlineFacebook } from "react-icons/md";

interface NavItem {
  name: string;
  to: string;
}
interface NavBlock {
  header: string;
  links: NavItem[];
}

interface Icon {
  icon: IconType;
  to: string;
}

const Footer: React.FC = () => {
  const navigation: NavBlock[] = [
    {
      header: "Get Connected",
      links: [
        { name: "physicians", to: "/" },
        {
          name: "hospitals",
          to: "/stories",
        },
      ],
    },
    {
      header: "Actions",
      links: [
        { name: "Find a Doctor", to: "/board" },
        {
          name: "Find a hospital",
          to: "/advisors",
        },
      ],
    },
    {
      header: "Company",
      links: [
        { name: "About Us", to: "/recent-blogs" },
        {
          name: "Career",
          to: "/new-blog",
        },
        {
          name: "Join our team",
          to: "/new-blog",
        },
      ],
    },
  ];

  const iconsData: Icon[] = [
    {
      icon: AiOutlineTwitter,
      to: "https://twitter.com/A2_SV",
    },
    {
      icon: MdOutlineFacebook,
      to: "https://www.facebook.com/profile.php?id=100085473798621",
    },
    {
      icon: AiFillYoutube,
      to: "https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A",
    },
    {
      icon: AiFillLinkedin,
      to: "https://www.linkedin.com/company/a2sv/mycompany/",
    },
    {
      icon: AiOutlineInstagram,
      to: "https://www.instagram.com/a2sv_org",
    },
  ];

  return (
    <section className="font-montserrat mt-auto text-primary-text text-sm bg-purple-600 flex flex-col gap-y-4 p-4 lg:text-base md:p-10">
      <div className="flex flex-col xl:flex-row items-center justify-between gap-4">
        <div className="flex flex-col items-center gap-4">
          <p className="font-bold text-3xl ">Hakim Hub</p>
        </div>

        <div className="w-full 2xl:w-2/3 flex flex-wrap justify-between lg:justify-evenly">
          {navigation.map((nav_item, index1) => (
            <div
              className="flex flex-col items-center gap-y-6 m-10"
              key={index1 + 1}
            >
              <h1 className="text-2xl self-start">{nav_item.header}</h1>
              <ul className="flex flex-col self-start gap-y-4">
                {nav_item.links.map((link_item, index2) => (
                  <li
                    key={parseInt(
                      (index1 + 1).toString() + (index2 + 1).toString()
                    )}
                  >
                    <Link
                      className="font-light text-secondary-text"
                      href={link_item.name}
                    >
                      {link_item.name}
                    </Link>
                  </li>
                ))}
              </ul>
            </div>
          ))}
        </div>
      </div>
      <div className="flex flex-col items-center gap-y-4 md:flex-row justify-between text-secondary-text">
        <p>
          <MdCopyright className="inline mr-2" />
          Hakim Hub, All right reserved
        </p>
        <div className="flex gap-4 text-2xl md:text-4xl ">
          {iconsData.map(({ icon: Icon, to }, index) => (
            <Link
              key={index}
              href={to}
              target="_blank"
              className="hover:text-gray-400"
            >
              <Icon />
            </Link>
          ))}
        </div>
      </div>
    </section>
  );
};

export default Footer;
