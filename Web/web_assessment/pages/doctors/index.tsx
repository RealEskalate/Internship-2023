import React, {useEffect, useState} from 'react';
import DoctorCard from "@/components/doctors/DoctorCard";
import SearchBar from "@/components/doctors/SearchBar";
import Pagination from "@/components/doctors/Pagination";
import {useSearchMutation} from "@/store/doctors/doctors-api";
import {useRouter} from "next/router";

const DoctorPage = () => {
    const [search, {data, isLoading, error}] = useSearchMutation();
    const [searchTerm, setSearchTerm] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 10;
    const indexOfLastDoctor = currentPage * itemsPerPage;
    const router = useRouter();


    useEffect(() => {
        const fetchDoctors = async () => {
            const response = await search(["", currentPage.toString(), itemsPerPage.toString()]);
        };

        fetchDoctors().then(r => console.log(">> error occurred haile", r));
    }, [search]);

    const handleSearchChange = async (value: string) => {
        await search([value, "1", itemsPerPage.toString()]);
    };

    const handleDetailPage = async (value: string) => {
        await router.push(`doctors/${value}`);
    }

    const paginate = async (pageNumber: number) => {
        setCurrentPage(pageNumber)
        await search(["", pageNumber.toString(), itemsPerPage.toString()])
    };

    return (
        <div className="flex flex-col items-center p-4">
            <div className="w-3/4 mx-auto">
                <SearchBar value={searchTerm} onChange={handleSearchChange}/>
            </div>

            {
                isLoading && <div>Loading...</div>
            }

            {
                error && <div>Error occurred processing your request</div>
            }

            {
                data != undefined &&
                <>
                    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-12 mt-4">
                        {data.data.map((data) => (
                            <DoctorCard key={data._id} doctor={data} onClick={() => handleDetailPage(data._id)}/>
                        ))}
                    </div>

                    <div className="mt-4">
                        <Pagination
                            itemsPerPage={itemsPerPage}
                            totalItems={data.totalCount}
                            paginate={paginate}
                            currentPage={currentPage}
                        />
                    </div>
                </>
            }

        </div>
    );
};

export default DoctorPage;