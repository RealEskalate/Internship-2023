import 'package:flutter/material.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_event.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_state.dart';
import 'package:mobile_assessement/presentation/widgets/broadcast_card.dart';


import '../../../../core/utils/colors.dart';
import '../bloc/bloc/weather_bloc.dart';

class SearchPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final searchBloc = BlocProvider.of<WeatherBloc>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text('Search'),
      ),
      body: Center(
        child: BlocBuilder<WeatherBloc, String>(
          bloc: searchBloc,
          builder: (context, state) {
            return TextField(
              controller: TextEditingController.fromValue(TextEditingValue(text: state)),
              decoration: InputDecoration(
                hintText: 'Search for something...',
              ),
              onSubmitted: (value) {
                searchBloc.add(LoadWeatherEvent(city:value));
              },
            );
          },
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          searchBloc.add(searchBloc.state);
        },
        child: Icon(Icons.search),
      ),
    );
  }
}