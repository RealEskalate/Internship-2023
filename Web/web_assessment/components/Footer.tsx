import Link from "next/link";
import {
  FaFacebook,
  FaInstagram,
  FaLinkedin,
  FaTwitter,
  FaYoutube,
} from "react-icons/fa";
import { LinkItem } from "@/types/footer-navigation";
import { AiOutlineRight } from "react-icons/ai";

const Footer: React.FC = () => {
  const linkItems: LinkItem[] = [
    {
      title: "Get Connected",
      links: [
        { name: "For Physicians", path: "/" },
        { name: "For Hospitals", path: "/" },
      ],
    },
    {
      title: "Actions",
      links: [
        { name: "For a doctor", path: "/" },
        { name: "For a hospital", path: "/" },
      ],
    },
    {
      title: "Company",
      links: [
        { name: "About us", path: "" },
        { name: "Carries", path: "" },
        { name: "Join Our Team", path: "" },
      ],
    },
  ];

  const socialMedialinks = [
    {
      icon: FaTwitter,
      url: "https://twitter.com/A2_SV",
    },
    {
      icon: FaFacebook,
      url: "https://www.facebook.com/profile.php?id=100085473798621",
    },
    {
      icon: FaYoutube,
      url: "https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A",
    },
    {
      icon: FaLinkedin,
      url: "https://www.linkedin.com/company/a2sv/mycompany/",
    },
    {
      icon: FaInstagram,
      url: "https://www.instagram.com/a2sv_org",
    },
  ];

  return (
    <footer className="border-y border-text-secondary sm:px-6 px-12 col bg-[#5D5FEF] text-white mt-5">
      <div className="px-6 sm:flex justify-between items-center space-y-12 sm:space-y-0 divide-y divide-y-reverse sm:py-12 py-3 sm:divide-y-0 sm:space-x-12 bg-[5D5FEF]">
        <div className="pb-8 sm:pt-0 basis-1/3 ">
          <h3 className="text-lg font-semibold my-6 float-left text-white">
            Hakim Hub
          </h3>
        </div>

        {linkItems.map((linkItem, index) => {
          return (
            <div key={index} className="sm:pt-0 basis-1/5 self-start">
              <h3 className="font-semibold mb-6">{linkItem.title}</h3>
              <ul className="flex flex-col text-secondary-text space-y-4">
                {linkItem.links.map(({ path, name }, index) => (
                  <li key={index} className="flex">
                    <AiOutlineRight />
                    <Link href={path}>{name}</Link>
                  </li>
                ))}
              </ul>
            </div>
          );
        })}
      </div>

      <div className="md:border-t border-neutral-200 sm:flex mx-auto md:justify-between py-8">
        <p className="text-sm text-secondary-text py-4 sm:py-0 flex ">
          <div>Privacy Policy</div>
          <div className="ml-10">Terms of Use</div>
        </p>

        <div className="text-secondary-text flex align-middle justify-center space-x-6 text-xl">
          {socialMedialinks.map(({ icon: Icon, url }, index) => {
            return (
              <Link key={index} href={url} target="_blank">
                {<Icon />}
              </Link>
            );
          })}
        </div>
      </div>
    </footer>
  );
};

export default Footer;
