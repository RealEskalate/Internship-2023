import 'package:flutter/material.dart';

class PostCard extends StatelessWidget {
  const PostCard({Key? key, required this.titleText, required this.description, required this.postImage})
      : super(key: key);
  final String titleText;
  final String description;
  final String postImage;

  @override
  Widget build(BuildContext context) {
    var screenWidth = MediaQuery.of(context);
    return Container(
      height: screenWidth.size.height * 0.25,
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(25.0),
        ),
        child: Column(
          children: [
            Row(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(30, 30, 10, 0),
                  child: Container(
                    width: screenWidth.size.width * 0.15,
                    height: screenWidth.size.width * 0.23,
                    decoration: BoxDecoration(
                        image: DecorationImage(
                          image: AssetImage(postImage),
                          fit: BoxFit.cover,
                        ),
                        borderRadius: BorderRadius.all(Radius.circular(20))),
                  ),
                ),
                SizedBox(width: screenWidth.size.width * 0.05),
                Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                      child: Text(
                        titleText,
                        style: TextStyle(
                            fontSize: 17, color: Colors.blue.withOpacity(0.6)),
                      ),
                    ),
                    Padding(
                      padding: EdgeInsets.fromLTRB(0, 0, 0, 20),
                      child: Text(
                        description,
                        style: const TextStyle(
                            fontSize: 15, fontWeight: FontWeight.w600),
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Row(children: const [
                          Icon(
                            Icons.thumb_up,
                            color: Colors.grey,
                          ),
                          Text('2.1k')
                        ]),
                        SizedBox(width: 23),
                        Row(
                          children: const [
                            Icon(Icons.schedule),
                            Text('1hr ago')
                          ],
                        ),
                        SizedBox(width: 23),
                        const Icon(
                          Icons.bookmark,
                          color: Colors.blue,
                        ),
                        const Text('        ')
                      ],
                    )
                  ],
                )
              ],
            )
          ],
        ),
      ),
    );
  }
}
