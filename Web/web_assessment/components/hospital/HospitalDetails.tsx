import { useGetHospitalDetailQuery } from "@/store/features/hospital-details-api";
import { useRouter } from "next/router";
import { LoadingPage } from "../common/Loading";
import { MockDetail } from "./HospitalDetailMock";

const HospitalDetails: React.FC = () => {
  const router = useRouter();
  const { id } = router.query;

  const { data: hospital, isLoading, isError } = useGetHospitalDetailQuery(id);

  if (isLoading) {
    return <LoadingPage />;
  }
  if (isError) {
    return <MockDetail />;
  }
  return (
    <div>
      <div>Region</div>
      <div>NAME</div>
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
