import HospitalCard from "../../components/HospitalCard";
import { useGetHospitalMutation, useSearchMutation } from "@/store/features/api";
import { useState, useEffect } from "react";
import { HospitalResponse } from "../../type/HospitslList";
import Link from "next/link";

const HospitalList: React.FC = () => {
  const [getHospital, { isLoading, isError, error }] = useGetHospitalMutation();
  const [hospital, setHospital] = useState<HospitalResponse[]>([]);
  const [inputValue, setValue] = useState("");
  const [search, { isLoading: isLaodingSearch, isError: isErrorSearch, error: errorSearch }] = useSearchMutation();

  const handleGetHospital = async () => {
    try {
      const response = await getHospital();
      if ('data' in response) {
        console.log(response)
        setHospital(response.data);
      } else {
        console.log(response.error);
      }
    } catch (error) {
      console.log(error);
    }
  };
  
  const handleSearch = async (event: React.FormEvent) => {
    event.preventDefault();
    setValue((event.target as HTMLInputElement).value);
    try {
      const response = await search(inputValue);
      if (inputValue === "") {
        handleGetHospital();
      } else {
        if ('data' in response) {
          setHospital(response.data.data);
        } else {
          console.log(response.error);
        }
      }
    } catch (error) {
      console.log("Error!!");
    }
  };

  useEffect(() => {
    handleGetHospital();
  }, []);

  return (
    <div className="hospital-list">
      <section>
        <form onSubmit={handleGetHospital}>
          <input
            type="text"
            value={inputValue}
            onChange={(e) => setValue(e.target.value)}
            placeholder="Search..."
            onClick={handleSearch}
          />
        </form>
      </section>

      <button type="submit" disabled={isLoading}>
        {isLoading ? "Creating data..." : "Create Data"}
      </button>

      <div className="grid grid-row-4">
        {hospital.map((hospitalItem) => (
          <Link key={hospitalItem._id} href={`hospital-profile/${hospitalItem._id}`} target="_blank">
            <HospitalCard 
            coverPhoto={hospitalItem.coverPhoto}
            institutionName={hospitalItem.institutionName}
            address={hospitalItem.address}
            phoneNumbers={hospitalItem.phoneNumbers}
            emails={hospitalItem.emails}
            availability={hospitalItem.availability}
            />
          </Link>
        ))}
      </div>
    </div>
  );
};

export default HospitalList;