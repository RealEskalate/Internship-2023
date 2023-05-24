import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weatherify/presentation/screen/detail_page.dart';

import '../bloc/bloc/weather_bloc.dart';

class HomePage extends StatelessWidget {
  final TextEditingController _searchController = TextEditingController();
  
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xffF2F2F2),
          appBar: AppBar(
            elevation: 0,
            foregroundColor:  Color(0xff3C2DB9),
            backgroundColor: Color(0xffF2F2F2),
            title: Text('Choose a city' ,),
            centerTitle: true,
          ),
          body: Column(
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Row(
                  children: [
                    Expanded(
                      child: TextField(
                        controller: _searchController,
                        decoration: InputDecoration(

                          fillColor: Colors.white,
                          hintText: 'Search',
                          prefixIcon: const Icon(Icons.search),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(10),
                          ),
                        ),
                      ),
                    ),
                    SizedBox(width: 10),
                    
                    BlocConsumer<WeatherBloc, WeatherState>(
                      listener: (context, state) {

                        if (state is WeatherLoaded){
                              Navigator.push(
                                                context,
                                                MaterialPageRoute(
                                                    builder: (context) =>
                                                        DetailPage(weather: state.weather)));
                        }

                        
                      },
                      builder: (context, state) {

                        return ElevatedButton(
                                          child: Text('Search'),
                                          style: ElevatedButton.styleFrom(backgroundColor: Color(0xffFFBA25),),
                                          onPressed: () {
                                            String searchText = _searchController.text;
                                            (context).read<WeatherBloc>().add(GetWeatherEvent( city: searchText));
                    
                                            
                                            // Do something with searchText
                                          },
                                        );
                      },
                    ),
                  ],
                ),
              ),
             
            ],
          ),
        );
      
  }
}