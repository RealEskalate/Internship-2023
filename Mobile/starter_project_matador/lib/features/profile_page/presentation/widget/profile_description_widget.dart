import 'package:flutter/material.dart';

class Profile_description extends StatefulWidget {
  const Profile_description({super.key});

  @override
  State<Profile_description> createState() => _Profile_descriptionState();
}

class _Profile_descriptionState extends State<Profile_description> {
  @override
  Widget build(BuildContext context) {
    var screenWidth = MediaQuery.of(context);
    return Container(
      width: screenWidth.size.width * 0.7,
      height: screenWidth.size.height * 0.4,
      child: Card(
        shape:
            RoundedRectangleBorder(borderRadius: BorderRadius.circular(20.0)),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                Padding(
                  padding: const EdgeInsets.all(18.0),
                  child: Container(
                    width: screenWidth.size.width * 0.15,
                    height: screenWidth.size.width * 0.15,
                    decoration: const BoxDecoration(
                        image: DecorationImage(
                          image: AssetImage('assets/images/profile.jpg'),
                          fit: BoxFit.cover,
                        ),
                        borderRadius: BorderRadius.all(Radius.circular(20))),
                  ),
                ),
                SizedBox(width: screenWidth.size.width * 0.05),
                Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    const Text(
                      '@joviedan',
                      style: TextStyle(
                          fontSize: 17,
                          color: Color.fromARGB(255, 5, 46, 78),
                          fontWeight: FontWeight.bold),
                    ),
                    const SizedBox(height: 5),
                    Text('Jovi Daniel',
                        style: TextStyle(
                            fontSize: 17,
                            color: Colors.black.withOpacity(0.6))),
                    const SizedBox(height: 10),
                    Text(
                      'UX designer',
                      style: TextStyle(
                          fontSize: 17, color: Colors.blue.withOpacity(0.6)),
                    )
                  ],
                )
              ],
            ),
            Padding(
              padding: EdgeInsets.fromLTRB(25, 0, 0, 0),
              child: Text(
                'About me',
                style: TextStyle(
                    fontSize: 18, color: Colors.black.withOpacity(0.6)),
              ),
            ),
            SizedBox(height: screenWidth.size.height * 0.03),
            Padding(
              padding: const EdgeInsets.fromLTRB(25, 0, 40, 0),
              child: Text(
                  'Madison Blackstone is a director of user experience design with experience managing global teams.',
                  style: TextStyle(
                      fontSize: 16,
                      height: 1.7,
                      color: Colors.black.withOpacity(0.6))),
            )
          ],
        ),
      ),
    );
  }
}
