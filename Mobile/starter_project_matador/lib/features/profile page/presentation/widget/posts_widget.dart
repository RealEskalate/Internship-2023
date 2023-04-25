import 'package:flutter/material.dart';

//The first Card in My Posts section
class Posts extends StatefulWidget {
  const Posts({super.key});

  @override
  State<Posts> createState() => _PostsState();
}

class _PostsState extends State<Posts> {
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
            Padding(
              padding: const EdgeInsets.fromLTRB(30, 15, 0, 0),
              child: Row(
                children: [
                  const Text(
                    'My Posts',
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.w600),
                  ),
                  SizedBox(width: screenWidth.size.width * 0.55),
                  const Icon(
                    Icons.grid_view,
                    color: Color.fromARGB(255, 6, 90, 159),
                  ),
                  SizedBox(width: 30),
                  const Icon(
                    Icons.toc,
                    color: Colors.grey,
                    size: 30,
                  ),
                ],
              ),
            ),
            Row(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(30, 10, 10, 0),
                  child: Container(
                    width: 100,
                    height: 120,
                    decoration: const BoxDecoration(
                        image: DecorationImage(
                          image: AssetImage('../assets/laser.jpg'),
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
                        'BIG DATA                                  ',
                        style: TextStyle(
                            fontSize: 17, color: Colors.blue.withOpacity(0.6)),
                      ),
                    ),
                    const Padding(
                      padding: EdgeInsets.fromLTRB(0, 0, 0, 20),
                      child: Text(
                        'Why Big Data Needs Thick Data?',
                        style: TextStyle(
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

//The Second card in my posts section

class Second_post extends StatefulWidget {
  const Second_post({super.key});

  @override
  State<Second_post> createState() => _Second_postState();
}

class _Second_postState extends State<Second_post> {
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
            Padding(
              padding: const EdgeInsets.fromLTRB(30, 5, 0, 0),
              child: Row(
                children: const [
                  Text(
                    '',
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.w600),
                  ),
                ],
              ),
            ),
            Row(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(30, 10, 10, 0),
                  child: Container(
                    width: 100,
                    height: 120,
                    decoration: const BoxDecoration(
                        image: DecorationImage(
                          image: AssetImage('../assets/board.jpg'),
                          fit: BoxFit.cover,
                        ),
                        borderRadius: BorderRadius.all(Radius.circular(20))),
                  ),
                ),
                const SizedBox(width: 15),
                Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                      child: Text(
                        'UX DESIGN                                  ',
                        style: TextStyle(
                            fontSize: 17, color: Colors.blue.withOpacity(0.6)),
                      ),
                    ),
                    const Padding(
                      padding: EdgeInsets.fromLTRB(0, 0, 0, 20),
                      child: Text(
                        'Why Big Data Needs Thick Data?',
                        style: TextStyle(
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
                        const Icon(Icons.bookmark),
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
