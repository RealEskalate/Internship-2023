import Link from 'next/link';
import { FaFacebook, FaInstagram, FaLinkedin, FaYoutube } from 'react-icons/fa';

const Footer: React.FC = () => {
  const linkItems = [
    {
      title: 'Get Connected',
      links: [
        { name: '> For Physicians', path: '/' },
        { name: '> For Hospitals', path: '/' },
      ],
    },
    {
      title: 'Actions',
      links: [
        { name: '> Find a doctor', path: '/' },
        { name: '> Find a hospital', path: '/' },
      ],
    },
    {
      title: 'Company',
      links: [
        { name: '> About Us', path: '/' },
        { name: '> Career', path: '/' },
        { name: '> Join our team', path: '/' },
      ],
    },
  ];

  const socialMediaLinks = [
    {
      icon: FaFacebook,
      url: 'https://www.facebook.com/profile.php?id=100085473798621',
    },
    {
      icon: FaInstagram,
      url: 'https://www.instagram.com/a2sv_org',
    },
    {
      icon: FaYoutube,
      url: 'https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A',
    },
    {
      icon: FaLinkedin,
      url: 'https://www.linkedin.com/company/a2sv/mycompany/',
    },
  ];

  return (
    <footer className="mt-auto border-t border-text-secondary text-white sm:px-6 px-12 bg-[#7879F1]">
      <div className="px-6 sm:flex justify-between items-center space-y-12 sm:space-y-0 divide-y divide-y-reverse sm:py-12 py-3 sm:divide-y-0 sm:space-x-12">
        <div className="pb-8 sm:pb-0 sm:w-1/5 hidden lg:block">
          {/* Add your content here */}
          <h3 className="text-lg font-bold my-8">Hakim Hub</h3>
        </div>

        <div className="pb-8 sm:pt-0 sm:w-1/3">
          
        </div>

        {linkItems.map((linkItem, index) => (
          <div key={index} className="sm:pt-0 sm:w-1/5 self-start">
            <h3 className="font-semibold mb-6">{linkItem.title}</h3>
            <ul className="flex flex-col text-secondary-text space-y-4">
              {linkItem.links.map(({ path, name }, index) => (
                <li key={index}>
                  <Link href={path}>{name}</Link>
                </li>
              ))}
            </ul>
          </div>
        ))}
      </div>

      <div className="md:border-t border-neutral-200 sm:flex mx-auto md:justify-between py-8">
        <p className="text-sm text-secondary-text py-4 sm:py-0">
          <span className="text-xl px-1 text-bold font-bold"></span> Privacy policy{' '}
          <span className="ml-6 font-bold">Terms of use</span>
        </p>

        <div className="text-secondary-text flex align-middle justify-center space-x-6 text-xl">
          {socialMediaLinks.map(({ icon: Icon, url }, index) => (
            <Link key={index} href={url} target="_blank">
              <Icon />
            </Link>
          ))}
        </div>
      </div>
    </footer>
  );
};

export default Footer;
