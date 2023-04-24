import 'package:flutter/material.dart';

class WriteArticlePage extends StatelessWidget {
  const WriteArticlePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;
    final bool isPortrait = MediaQuery.of(context).orientation == Orientation.portrait;

    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white,
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Colors.black),
          onPressed: () {},
        ),
        title: const Text(
          'New Article',
          style: TextStyle(color: Colors.black),
          textAlign: TextAlign.center,
        ),
        centerTitle: true,
      ),
      body: Padding(
        padding: const EdgeInsets.all(10.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              height: screenSize.height * 0.02,
            ),
            SizedBox(
              height: screenSize.height * 0.06,
              child: const TextField(
                decoration: InputDecoration(
                  labelText: 'Add Title',
                ),
              ),
            ),
            SizedBox(height: screenSize.height * 0.01),
            SizedBox(
              height: screenSize.height * 0.06,
              child: const TextField(
                decoration: InputDecoration(
                  labelText: 'Add Subtitle',
                ),
              ),
            ),
            SizedBox(height: screenSize.height * 0.02),
            Row(
              children: [
                Expanded(
                  child: SizedBox(
                    height: screenSize.height * 0.06,
                    child: const TextField(
                      decoration: InputDecoration(
                        labelText: 'Add Tags',
                      ),
                    ),
                  ),
                ),
                IconButton(
                  onPressed: () {},
                  icon: const Icon(Icons.add),
                ),
              ],
            ),
            SizedBox(height: screenSize.height * 0.01),
            Text(
              'Add as many tags as you want',
              textAlign: TextAlign.start,
              style: TextStyle(fontSize: screenSize.height * 0.02),
            ),
            SizedBox(height: screenSize.height * 0.05),
            Expanded(
              child: Padding(
                padding: EdgeInsets.symmetric(vertical: screenSize.height * 0.02),
                child: Container(
                  decoration: BoxDecoration(
                    color: Colors.grey[200],
                    borderRadius: BorderRadius.circular(10),
                  ),
                  padding: EdgeInsets.all(screenSize.height * 0.02),
                  child: const TextField(
                    decoration: InputDecoration.collapsed(
                      hintText: 'Add Content',
                    ),
                    expands: true,
                    minLines: null,
                    maxLines: null,
                  ),
                ),
              ),
            ),
            SizedBox(height: screenSize.height * 0.05),
            Center(
              child: SizedBox(
                width: isPortrait ? screenSize.width * 0.3 : screenSize.width * 0.15,
                height: screenSize.height * 0.06,
                child: ElevatedButton(
                  onPressed: () {},
                  style: ElevatedButton.styleFrom(
                    shadowColor: Colors.blue,
                    shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
                  ),
                  child: const Text('Publish', style: TextStyle(fontSize: 20)),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}