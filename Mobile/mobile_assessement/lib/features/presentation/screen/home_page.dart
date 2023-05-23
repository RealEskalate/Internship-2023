import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/presentation/bloc/city_weather_bloc.dart';
import 'package:mobile_assessement/features/presentation/screen/detail_page.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        backgroundColor: Colors.white,
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
                const Expanded(
                  child: TextField(
                    decoration: InputDecoration(
                      hintText: 'Search a new city',
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                const SizedBox(width: 8),
                BlocConsumer<CityWeatherBloc, CityWeatherState>(
                  listener: (context, state) {
                    // TODO: implement listener
                  },
                  builder: (context, state) {
                    if (state is Loadingstate) {
                      return const CircularProgressIndicator();
                    } else if (state is LoadedState) {
                      
                    }
                    return ElevatedButton(
                      onPressed: () {
                        // Handle search button press
                      },
                      child: const Text('Search'),
                    );
                  },
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
        ],
      ),
    );
  }
}
