import 'package:flutter/material.dart';
import 'package:dartsmiths/core/utils/ui_converter.dart';

// ignore: camel_case_types

Widget description = Text(
  'That marked a turnaround from last year, when the social network reported a decline in users for the first time.\n The drop wiped billions from the firms market value.\n Since executives disclosed the fall in February, the firms share price has nearly halved.But shares jumped 19% in after-hours trade on Wednesday.',
  maxLines: null,
  style: TextStyle(fontSize: UIConverter.designWidth * 0.04),
);

class article_reading extends StatelessWidget {
  const article_reading({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        debugShowCheckedModeBanner: false,
        home: Builder(builder: (BuildContext context) {
          return Scaffold(
              body: SafeArea(
            child: Stack(
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
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: const [
                                Icon(Icons.arrow_back),
                                Icon(Icons.more_horiz)
                              ],
                            ),
                            SizedBox(
                              height: UIConverter.designHeight * 0.03,
                            ),
                            const Text(
                              'Four Things Everyone Needs To Know',
                              style: TextStyle(
                                fontWeight: FontWeight.bold,
                                fontSize: 25,
                              ),
                            ),
                            SizedBox(
                              height: UIConverter.designHeight * 0.03,
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Row(
                                  children: [
                                    ClipRRect(
                                      borderRadius: BorderRadius.circular(
                                          UIConverter.designWidth * 0.3),
                                      child: Image.asset(
                                        'images/fashion1.jpg',
                                        width: UIConverter.designWidth * 0.1,
                                        height: UIConverter.designHeight * 0.06,
                                      ),
                                    ),
                                    SizedBox(
                                      width: UIConverter.designHeight * 0.03,
                                    ),
                                    Column(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: const [
                                        Text(
                                          'Richard Gervan',
                                          style: TextStyle(color: Colors.blue),
                                        ),
                                        Text(
                                          '2m ago',
                                          style: TextStyle(color: Colors.blue),
                                        )
                                      ],
                                    ),
                                  ],
                                ),
                                const Icon(Icons.bookmark_add_outlined)
                              ],
                            ),
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
                        child: description,
                      ),
                    ],
                  ),
                ),
                Positioned(
                  bottom: 10,
                  right: 10,
                  child: TextButton(
                      onPressed: () {},
                      style: TextButton.styleFrom(
                          backgroundColor: Colors.blue,
                          padding: const EdgeInsets.all(10)),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: const [
                          Icon(
                            Icons.thumb_up_alt_outlined,
                            color: Colors.white,
                          ),
                          SizedBox(
                            width: 10,
                          ),
                          Text(
                            '2.3k',
                            style: TextStyle(color: Colors.white),
                          ),
                        ],
                      )),
                )
              ],
            ),
          ));
        }));
  }
}
