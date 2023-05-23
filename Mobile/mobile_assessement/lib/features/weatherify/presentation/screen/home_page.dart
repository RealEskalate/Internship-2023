import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/features/weatherify/presentation/widgets/action_button.dart';

import '../../../../core/utils/colors.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  TextEditingController cityNameController = TextEditingController();
  final GlobalKey formKey = GlobalKey();
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: scaffoldBackgroundColor,
        body: Padding(
          padding: EdgeInsets.all(MediaQuery.of(context).size.width * 0.05),
          child: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const TitleText(),
                SizedBox(
                  height: MediaQuery.of(context).size.height * 0.04,
                ),
                Row(
                  children: [
                    Expanded(
                      child: SizedBox(
                        height: MediaQuery.of(context).size.height * 0.05,
                        child: Center(
                          child: Form(
                            key: formKey,
                            child: TextField(
                              controller: cityNameController,
                              decoration: InputDecoration(
                                filled: true,
                                fillColor: Colors.white,
                                prefixIcon: Icon(Icons.search),
                                labelText: 'Search a new city',
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.symmetric(
                                    vertical:
                                        MediaQuery.of(context).size.height *
                                            0.1,
                                    horizontal:
                                        MediaQuery.of(context).size.width *
                                            0.04),
                              ),
                            ),
                          ),
                        ),
                      ),
                    ),
                    ActionButton(
                      height: MediaQuery.of(context).size.height * 0.05,
                      child: Text(
                        "Search",
                        style: TextStyle(fontSize: 17),
                      ),
                    )
                  ],
                ),
                SizedBox(
                  height: MediaQuery.of(context).size.height * 0.05,
                ),
                Container(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [Text("My Fav Cites")],
                  ),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}

class TitleText extends StatelessWidget {
  const TitleText({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Text(
      "Choose a city",
      style: TextStyle(
          color: primaryTextColor,
          fontSize: MediaQuery.of(context).size.height * 0.03,
          fontWeight: FontWeight.bold),
    );
  }
}
