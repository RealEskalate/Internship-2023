import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/utils/colors.dart';
import '../bloc/weather_bloc.dart';
import '../widgets/custom_button.dart';
import '../widgets/custom_list_tile.dart';
import '../widgets/custom_text_field.dart';
import 'city_detail.dart';

class CitiesList extends StatelessWidget {
  CitiesList({super.key});

  final searchTextController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromRGBO(249, 245, 253, 1),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Choose a city",
                style: TextStyle(
                    color: primaryColor,
                    fontSize: 20,
                    fontWeight: FontWeight.w500,
                    fontFamily: "Roboto"),
              ),
              SizedBox(height: 10),
              Row(
                children: [
                  Expanded(
                    flex: 4,
                    child: CustomTextField(
                        textController: searchTextController,
                        prefixIcon: Icons.search,
                        hintText: "Search a new city...",
                        height: 48,
                        width: 86),
                  ),
                  SizedBox(width: 10),
                  BlocConsumer<WeatherBloc, WeatherState>(
                    listener: (context, state) {
                      if (state is SearchSuccessState) {
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) =>
                                  WeatherDetail(state.detail)),
                        );
                      }
                    },
                    builder: (context, state) {
                      if (state is SearchLoadingState) {
                        return Center(
                          child: CircularProgressIndicator(),
                        );
                      } else if (state is SearchSuccessState) {
                        return Text("Success");
                      } else if (state is SearchFailureState) {
                        return Expanded(
                          flex: 1,
                          child: CustomButton(
                            onTap: () {
                              print(searchTextController.text);
                              context.read<WeatherBloc>().add(
                                  SearchCityEvent(searchTextController.text));
                            },
                            text: "Failed",
                          ),
                        );
                      } else {
                        return Expanded(
                          flex: 1,
                          child: CustomButton(
                            onTap: () {
                              print(searchTextController.text);
                              print("what about me");
                              context.read<WeatherBloc>().add(
                                  SearchCityEvent(searchTextController.text));
                            },
                            text: "Search",
                          ),
                        );
                      }
                    },
                  )
                ],
              ),
              SizedBox(height: 10),
              Text(
                "My Fav Cities",
                style: TextStyle(
                    color: primaryColor,
                    fontSize: 15,
                    fontWeight: FontWeight.w500,
                    fontFamily: "Roboto"),
              ),
              SizedBox(height: 10),
              CustomListTile(),
            ],
          ),
        ),
      ),
    );
  }
}
