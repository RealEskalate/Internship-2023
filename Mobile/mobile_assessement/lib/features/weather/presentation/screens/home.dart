import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../../../../dependency_injection.dart' as di;
import '../bloc/weather_bloc.dart';
import 'detail.dart';

class HomePage extends StatefulWidget {
  const HomePage({
    super.key,
  });
  @override
  State<HomePage> createState() => _HomePageState();
}

// class _HomePageState extends State<HomePage> {
//   late WeatherBloc _weatherBloc;
//   TextEditingController _searchController = TextEditingController();

//   void initState() {
//     super.initState();
//     _weatherBloc = _weatherBloc = di.sl<WeatherBloc>();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       backgroundColor: const Color.fromRGBO(242, 242, 242, 1.0),
//       appBar: AppBar(
//         elevation: 0,
//         title: const Text(
//           'Choose a city',
//           style: TextStyle(color: Colors.purple),
//         ),
//         centerTitle: true,
//       ),
//       body: Column(
//         crossAxisAlignment: CrossAxisAlignment.stretch,
//         children: [
//           Padding(
//             padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
//             child: Row(
//               children: [
//                 Expanded(
//                   child: TextField(
//                     controller: _searchController,
//                     decoration: const InputDecoration(
//                       hintText: 'Search a new city',
//                       border: OutlineInputBorder(),
//                     ),
//                   ),
//                 ),
//                 const SizedBox(width: 8),
//                 ElevatedButton(
//                   onPressed: () {
//                     final cityName = _searchController.text;
//                     _weatherBloc.add(GetWeatherEvent(cityName: cityName));

//                     BlocBuilder<WeatherBloc, WeatherState>(
//                       builder: (context, state) {
//                         print("the stat is $state");
//                         if (state is WeatherLoadingState) {
//                           return const Scaffold(
//                             body: Center(
//                               child: CircularProgressIndicator(),
//                             ),
//                           );
//                         } else if (state is WeatherSuccessState) {
//                           // final weather = state.weather;
//                           Navigator.push(
//                             context,
//                             MaterialPageRoute(
//                               builder: (context) => DetailPage(),
//                             ),
//                           );
//                         }
//                         return const Text('Feaching Failed');
//                       },
//                     );
//                   },
//                   child: Text('Search'),
//                 ),
//               ],
//             ),
//           ),
//           const Padding(
//             padding: EdgeInsets.all(16),
//             child: Text(
//               'My Fav Cities',
//               style: TextStyle(fontSize: 18),
//             ),
//           ),
//           Expanded(
//             child: ListView.builder(
//               itemCount: 3, // Replace with the actual number of favorite cities
//               itemBuilder: (context, index) {
//                 return Card(
//                   child: Padding(
//                     padding: const EdgeInsets.all(16),
//                     child: Row(
//                       children: const [
//                         Expanded(
//                           child: Text(
//                             'New Mexico, USA',
//                             style: TextStyle(fontSize: 16),
//                           ),
//                         ),
//                         SizedBox(width: 8),
//                         Text(
//                           '28',
//                           style: TextStyle(fontSize: 16),
//                         ),
//                         SizedBox(width: 8),
//                         Icon(
//                           Icons
//                               .cloud, // Replace with the appropriate weather icon
//                           size: 24,
//                         ),
//                       ],
//                     ),
//                   ),
//                 );
//               },
//             ),
//           ),
//         ],
//       ),
//     );
//   }
// }

class _HomePageState extends State<HomePage> {
  late WeatherBloc _weatherBloc;
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _weatherBloc = di.sl<WeatherBloc>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromRGBO(242, 242, 242, 1.0),
      appBar: AppBar(
        backgroundColor: const Color.fromRGBO(
            242, 242, 242, 1.0), // Match the background color
        elevation: 0,
        title: const Text(
          'Choose a city',
          style: TextStyle(color: Colors.purple),
        ),
        centerTitle: true,
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _searchController,
                    decoration: InputDecoration(
                      hintText: 'Search a new city',
                      border: const OutlineInputBorder(),
                      filled: true,
                      fillColor: Colors.amberAccent[
                          700], // Set the search bar color to golden
                    ),
                  ),
                ),
                const SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    final cityName = _searchController.text;
                    _weatherBloc.add(GetWeatherEvent(cityName: cityName));
                  },
                  child: Text('Search'),
                ),
              ],
            ),
          ),
          const Padding(
            padding: EdgeInsets.all(16),
            child: Text(
              'My Fav Cities',
              style: TextStyle(fontSize: 18),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: 3, // Replace with the actual number of favorite cities
              itemBuilder: (context, index) {
                return Card(
                  child: Padding(
                    padding: const EdgeInsets.all(16),
                    child: Row(
                      children: const [
                        Expanded(
                          child: Text(
                            'New Mexico, USA',
                            style: TextStyle(fontSize: 16),
                          ),
                        ),
                        SizedBox(width: 8),
                        Text(
                          '28',
                          style: TextStyle(fontSize: 16),
                        ),
                        SizedBox(width: 8),
                        Icon(
                          Icons
                              .cloud, // Replace with the appropriate weather icon
                          size: 24,
                        ),
                      ],
                    ),
                  ),
                );
              },
            ),
          ),
          BlocConsumer<WeatherBloc, WeatherState>(
            listener: (context, state) {
              if (state is WeatherSuccessState) {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => DetailPage(
                      weather: state.weather,
                    ),
                  ),
                );
              }
            },
            builder: (context, state) {
              if (state is WeatherLoadingState) {
                return const Scaffold(
                  body: Center(
                    child: CircularProgressIndicator(),
                  ),
                );
              } else if (state is WeatherFailureState) {
                return const Text('Fetching Failed');
              } else {
                return const SizedBox.shrink();
              }
            },
          ),
        ],
      ),
    );
  }
}
