import Image from "next/image";
import Link from "next/link";

const HospitalDetails: React.FC = () => {
  return (
    <div>
      <div>Photo</div>
      <div>Name</div>
      <div>tags</div>
      <div>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Nobis dolore
        maiores, natus ducimus, harum tempore quaerat veritatis minima molestiae
        maxime labore vel quasi. Et fuga perspiciatis veritatis quidem, voluptas
        accusamus animi ipsa autem! A amet dolore quod vel eos quos, numquam est
        consequuntur possimus repudiandae dignissimos, nobis culpa similique
        optio.
      </div>
      <div>
        <div>Services</div>
        <div className="flex flex-wrap">
          <div>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
          </div>
          <div>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
          </div>
        </div>
      </div>
      <div className="border-2 border-black">
        <div>Contact Details</div>
        <div className="flex flex-wrap">
          <div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
          </div>
          <div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HospitalDetails;
