// ignore_for_file: camel_case_types

import 'package:dartsmiths/features/article/presentation/widgets/article_profile.dart';
import 'package:dartsmiths/features/article/presentation/widgets/like_button.dart';
import 'package:flutter/material.dart';
import 'package:dartsmiths/core/utils/ui_converter.dart';

String textValue =
    'That marked a turnaround from last year, when the social network reported a decline in users for the first time.\n The drop wiped billions from the firms market value.\n Since executives disclosed the fall in February, the firms share price has nearly halved.But shares jumped 19% in after-hours trade on Wednesday.';

String title = 'Four Things Everyone Needs To Know';

class article_reading extends StatelessWidget {
  const article_reading({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        debugShowCheckedModeBanner: false,
        home: Builder(builder: (BuildContext context) {
          return Scaffold(
            floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
            body: SafeArea(
              child: Column(
                children: [
                  SingleChildScrollView(
                    scrollDirection: Axis.vertical,
                    child: Column(
                      children: [
                        Padding(
                          padding: EdgeInsets.fromLTRB(
                              UIConverter.designWidth * 0.1,
                              UIConverter.designHeight * 0.1,
                              UIConverter.designWidth * 0.1,
                              UIConverter.designHeight * 0.02),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: const [
                                  Icon(Icons.arrow_back),
                                  Icon(Icons.more_horiz)
                                ],
                              ),
                              SizedBox(
                                height: UIConverter.designHeight * 0.03,
                              ),
                              Text(
                                title,
                                style: const TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 25,
                                ),
                              ),
                              SizedBox(
                                height: UIConverter.designHeight * 0.03,
                              ),
                              const article_profile(),
                            ],
                          ),
                        ),
                        Container(
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(20),
                          ),
                          height: UIConverter.designHeight * 0.25,
                          width: double.infinity,
                          child: ClipRRect(
                            borderRadius: const BorderRadius.only(
                                topLeft: Radius.circular(20),
                                topRight: Radius.circular(20)),
                            child: Image.asset(
                              'images/fashin3.jpg',
                              width: double.infinity,
                              fit: BoxFit.cover,
                            ),
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.fromLTRB(30, 25, 30, 0),
                          child: Text(
                            textValue,
                            maxLines: null,
                            style: TextStyle(
                                fontSize: UIConverter.designWidth * 0.04),
                          ),
                        ),
                      ],
                    ),
                  ),
                  // FloatingActionButton: like_button(),
                ],
              ),
              //
            ),
            floatingActionButton: const like_button(),
          );
        }));
  }
}
