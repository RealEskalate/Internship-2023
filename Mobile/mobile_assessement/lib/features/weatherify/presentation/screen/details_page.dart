import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/core/utils/colors.dart';
import 'package:mobile_assessement/features/weatherify/presentation/bloc/weatherify_bloc.dart';

class DetailsPage extends StatelessWidget {
  const DetailsPage({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<WeatherBloc, WeatherifyState>(
      builder: (context, state) => Scaffold(
        backgroundColor: scaffoldBackgroundColor,
        appBar: AppBar(
          backgroundColor: scaffoldBackgroundColor,
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              const Icon(
                Icons.arrow_back_ios,
                color: primaryTextColor,
              ),
              Column(
                children: const [
                  Text(
                    "state.cityName",
                    style: TextStyle(
                      color: Colors.black,
                    ),
                  ),
                  Text(
                    "state.date",
                    style: TextStyle(color: Colors.black, fontSize: 13),
                  ),
                ],
              ),
              IconButton(
                onPressed: () {},
                icon: const Icon(
                  Icons.favorite_outline,
                  color: Colors.black,
                ),
              )
            ],
          ),
        ),
        body: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(
              height: 40,
            ),
            const Center(
              child: Image(
                image: AssetImage("assets/images/sun_image.png"),
              ),
            ),
            const SizedBox(
              height: 40,
            ),
            const Padding(
              padding: EdgeInsets.all(8.0),
              child: Text(
                "Mostly Sunny",
                style: TextStyle(
                    color: primaryTextColor,
                    fontSize: 30,
                    fontWeight: FontWeight.bold),
              ),
            ),
            const Padding(
              padding: EdgeInsets.all(8.0),
              child: Text(
                "30",
                style: TextStyle(
                    color: primaryTextColor,
                    fontSize: 70,
                    fontWeight: FontWeight.bold),
              ),
            ),
            Expanded(
              child: Container(
                width: double.infinity,
                decoration: const BoxDecoration(
                  color: primaryTextColor,
                  borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(40),
                      topRight: Radius.circular(40)),
                ),
                child: Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: const [
                      SizedBox(
                        height: 40,
                      ),
                      Text(
                        "Every day",
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 18,
                        ),
                      ),
                      SizedBox(
                        height: 20,
                      ),
                      SingleDay(),
                      SizedBox(height: 20,),
                       SingleDay(),
                      SizedBox(height: 20,),
                       SingleDay(),
                      SizedBox(height: 20,)
                    ],
                  ),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}

class SingleDay extends StatelessWidget {
  const SingleDay({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Text("state.date", style: TextStyle(color: Colors.white),),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: const [
            Text(
              "23",
              style: TextStyle(color: Colors.white),
            ),
            Text(
              "49",
              style: TextStyle(color: Colors.white),
            ),
            Icon(
              Icons.cloud_upload,
              color: Colors.white,
            )
          ],
        )
      ],
    );
  }
}
