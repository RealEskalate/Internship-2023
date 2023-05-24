import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/data/datasources/local_datasources.dart';
import 'package:mobile_assessement/features/weather/data/datasources/remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/model/weather_model.dart';
import 'package:mobile_assessement/features/weather/data/repository/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/usercase/weather_usecase.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_event.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_search_status.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/detail_page.dart';

import '../../domain/entity/weather.dart';
import '../bloc/weather_bloc.dart';
import '../bloc/weather_state.dart';

class SearchCityPage extends StatefulWidget {
  const SearchCityPage({Key? key}) : super(key: key);

  @override
  State<SearchCityPage> createState() => _SearchCityPageState();
}

class _SearchCityPageState extends State<SearchCityPage> {
  List<String> cities = ['United Kingdom'];
  List<double> temprature = [28];
  final List<Weather> weather = [];
  final WeatherRemoteDataSource remoteDataSource = WeatherRemoteDataSource();
  final WeatherLocalDataSource localDataSource = WeatherLocalDataSource();
  _fetch(value) async {
    WeatherRepositoryImpl repository = WeatherRepositoryImpl(
      localDataSource: localDataSource,
      remoteDataSource: remoteDataSource,
    );
    GetWeatherForCityUseCase useCase = GetWeatherForCityUseCase(repository);
    final data = await useCase.call(value);
    return data;
  }

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => WeatherBloc(),
      child: Scaffold(
        backgroundColor: const Color(0xFFF5F4FF),
        body: BlocConsumer<WeatherBloc, WeatherState>(
          listener: (context, state) {},
          builder: (context, state) {
            if (state.formSubmittionStatus is SuccessStatus) {
              cities.add(state.cityName);
            } else {
              //Otherwise show a Progress bar until if fetchs data todo
            }
            return Padding(
              padding: const EdgeInsets.all(16),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Center(
                    child: Text(
                      'Choose City',
                      style: TextStyle(
                        color: Color(0xFF211772),
                        fontWeight: FontWeight.w700,
                        fontSize: 18,
                        fontFamily: 'Roboto',
                      ),
                    ),
                  ),
                  const SizedBox(height: 31),
                  const SizedBox(height: 8),
                  Row(
                    children: [
                      Expanded(
                        child: Container(
                          decoration: BoxDecoration(
                            color: Colors.white,
                            border: Border.all(color: Colors.grey),
                            borderRadius: BorderRadius.circular(8),
                          ),
                          child: TextField(
                            onSubmitted: (value) {
                              context
                                  .read<WeatherBloc>()
                                  .add(UpdateCityName(value));

                              final data = _fetch(value) as WeatherModel;
                              context
                                  .read<WeatherBloc>()
                                  .add(Submitted(weather: data));
                            },

                            decoration: const InputDecoration(
                              border: InputBorder.none,
                              focusedBorder: InputBorder.none,
                              hintText: 'Search a new city...',
                              prefixIcon: Icon(
                                Icons.search,
                                color: Colors.grey,
                                // Replace with desired icon color
                              ),
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(width: 8),
                      ElevatedButton(
                        onPressed: () {
                          // Handle search button press
                        },
                        style: ElevatedButton.styleFrom(
                          backgroundColor: const Color(0xFFFFBA25),
                        ),
                        child: const Text("Search"),
                      ),
                    ],
                  ),
                  const SizedBox(height: 16),
                  const Text(
                    'My Favorite Cities',
                    style: TextStyle(
                      color: Color(0xFF211772),
                      fontSize: 16,
                      fontWeight: FontWeight.w400,
                    ),
                  ),
                  const SizedBox(height: 20),
                  Expanded(
                    child: ListView.builder(
                      itemCount: cities
                          .length, // Replace with the actual count of cities
                      itemBuilder: (context, index) {
                        return Padding(
                          padding: const EdgeInsets.only(bottom: 16),
                          child: buildCityRow(
                            cities[0], // Replace with the actual city name
                            temprature[
                                index], // Replace with the actual temperature
                            Icons.wb_sunny,
                            const Color(0xFFFFBA25),
                          ),
                        );
                      },
                    ),
                  ),
                ],
              ),
            );
          },
        ),
      ),
    );
  }

  Widget buildCityRow(
    String cityName,
    double temperature,
    IconData iconData,
    Color color,
  ) {
    return Container(
      color: Colors.white,
      child: ListTile(
        title: TextButton(
          onPressed: () => {
            Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => DetailPage(
                    cityName: cityName,
                    isFavorite: true,
                  ),
                )),
          },
          child: Row(
            children: [
              const SizedBox(width: 8),
              Text(
                cityName,
                style: const TextStyle(
                  color: Color(0xFF575757),
                  fontFamily: 'Roboto',
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
              ),
              const Expanded(child: SizedBox()),
              Text(
                '$temperature°C',
                style: const TextStyle(
                  color: Color(0xFF211772),
                  fontSize: 24,
                  fontWeight: FontWeight.w500,
                  fontFamily: 'Roboto',
                ),
              ),
              const SizedBox(width: 20),
              Icon(iconData, color: color),
            ],
          ),
        ),
      ),
    );
  }
}
