import Image from "next/image";
import Link from "next/link";
const Footer: React.FC = () => {
  return (
    <div className="bg-primary divide-y p-10 text-text-primary">
      <div className="flex mb-5">
        <div className="w-1/2 font-extrabold text-2xl">HakimHub</div>
        <div className="flex w-1/2">
          <div className="w-1/3 ">
            <div className="font-bold">Get Connected</div>
            <div>-Lorem, ipsum.</div>
            <div>-Lorem, ipsum.</div>
          </div>
          <div className="w-1/3">
            <div className="font-bold">Actions</div>
            <div>-Lorem, ipsum.</div>
            <div>-Lorem, ipsum.</div>
          </div>
          <div className="w-1/3 ">
            <div className="font-bold">Company</div>
            <div>-Lorem, ipsum.</div>
            <div>-Lorem, ipsum.</div>
          </div>
        </div>
      </div>
      <div className="flex flex-wrap">
        <div className="w-2/3 flex self-center">
          <div className="mr-6 font-bold">Policy Privacy</div>
          <div className="font-bold">Terms of use</div>
        </div>
        <div className="flex flex-wrap w-1/3 self-center justify-end">
          <div className="mr-20 flex">
            <Link className="p-5 self-center" href={""}>
              <Image
                src="/image/facebook.png"
                alt={""}
                width={25}
                height={25}
              />
            </Link>

            <Link className="p-5 self-center" href={""}>
              <Image
                src="/image/linkedin.png"
                alt={""}
                width={25}
                height={25}
              />
            </Link>

            <Link className="p-5 self-center" href={""}>
              <Image src="/image/insta.png" alt={""} width={25} height={25} />
            </Link>

            <Link className="p-5 self-center" href={""}>
              <Image src="/image/twitter.png" alt={""} width={25} height={25} />
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Footer;
