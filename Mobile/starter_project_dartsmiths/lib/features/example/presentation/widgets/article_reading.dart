import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class article_reading extends StatelessWidget {
  const article_reading({super.key});

  @override
  Widget build(BuildContext context) {
    return Stack(
          children: [
          SingleChildScrollView(
            scrollDirection: Axis.vertical,
            child: Column(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(50, 50, 50, 20),
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
                      const SizedBox(
                        height: 20,
                      ),
                      const Text(
                        'Four Things Everyone Needs To Know',
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 25,
                        ),
                      ),
                      const SizedBox(
                        height: 20,
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Row(
                            children: [
                              ClipRRect(
                                borderRadius: BorderRadius.circular(18),
                                child: Image.asset(
                                  'images/fashion1.jpg',
                                  width: 40,
                                  height: 40,
                                ),
                              ),
                              const SizedBox(
                                width: 15,
                              ),
                              Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
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
                  height: 190,
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
                const Padding(
                    padding: EdgeInsets.fromLTRB(30, 25, 30, 0),
                    child: Text(
                        "That marked a turnaround from last year, when the social network reported a decline in users for the first time.\n The drop wiped billions from the firms market value.\n Since executives disclosed the fall in February, the firms share price has nearly halved.But shares jumped 19% in after-hours trade on Wednesday.",
                        style: TextStyle(
                          fontSize: 18,
                          color: Colors.blueGrey,
                          height: 1.5, // the height between text, default is null
                          // letterSpacing: 1.0
                        ))),
              ],
            ),
          ),
          Positioned(
            bottom: 10,
            right: 10,
            child: TextButton(onPressed: (){},
            style:
              TextButton.styleFrom(backgroundColor: Colors.blue, padding: EdgeInsets.all(10)), 
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: const [
                Icon(Icons.thumb_up_alt_outlined, color: Colors.white,),
                SizedBox(width: 10,),
                Text('data',
                style: TextStyle(color: Colors.white),),
              ],
            )
            ),
          )
          ],
        );
  }
}