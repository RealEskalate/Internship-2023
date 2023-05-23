import { useRouter } from 'next/router';
import {useFetchDoctorDetailsMutation} from "@/store/doctors/doctors-api";
import {useEffect} from "react";

const DoctorDetailPage = () => {
    const router = useRouter();
    const { doctorId } = router.query;
    const [fetchDoctorDetail, {data, isLoading, error}] = useFetchDoctorDetailsMutation();

    useEffect(() => {
        const fetchDoctors = async () => {
            try {
                console.log(">> doctorId", doctorId);
                console.log(">> router.query: ", router.query)
                const response = await fetchDoctorDetail(doctorId as string);
                if ('data' in response) {
                    const doctors = response.data; // Assuming the response contains the doctors data
                    console.log(">>", doctors);
                }
                // Do something with the doctors data

            } catch (error) {
                // Handle error
                console.error(error);
            }
        };

        fetchDoctors().then(r => console.log(">> error occurred haile", r));
    }, []);

    return (
        <div>
            { isLoading && <p>Loading...</p> }
            { data != undefined &&
                <div className="bg-gray-100 p-8">
                    <h1 className="text-2xl font-bold mb-4">Doctor Detail</h1>
                    <p className="mb-2">Doctor ID: {doctorId}</p>
                    <div className="flex items-center justify-center mb-4">
                        <div className="w-32 h-32 bg-gray-300 rounded-full overflow-hidden">
                            <img src={data.photo} alt="Doctor" className="w-full h-full object-cover"/>
                        </div>
                    </div>
                    <div className="flex">
                        <div className="mr-4">
                            <p className="text-xl font-bold mb-2">{data.fullName}</p>
                            <p className="text-gray-500">{data.speciality[0].name}</p>
                        </div>
                        <div>
                            <p className="text-gray-500">{data.education[0]}</p>
                            <p>{data.mainInstitution.institutionName}</p>
                        </div>
                    </div>
                    <div className="mt-4">
                        <h2 className="text-lg font-bold mb-2">About</h2>
                        <p>{data.summary}</p>
                    </div>
                    <div className="mt-4">
                        <h2 className="text-lg font-bold mb-2">Education</h2>
                        <ul>
                            {data.education.map((item, index) => (
                                <li key={index} className="mb-2">
                                    <p>{item}</p>
                                    {/*<p>{item.year}</p>*/}
                                    {/*<p>{item.degree}</p>*/}
                                </li>
                            ))}
                        </ul>
                    </div>
                    <div className="mt-4">
                        <h2 className="text-lg font-bold mb-2">Contact Info</h2>
                        <p>
                            <span className="text-indigo-500">Phone Number:</span> +251-985-678-345
                        </p>
                        <p>
                            <span className="text-indigo-500">Email:</span> {data.email}
                        </p>
                    </div>
                </div>
            }
</div>
    );


};

export default DoctorDetailPage;

