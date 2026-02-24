// taskManager.js

let tasks = [];
const addTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasks.push(task);
    callback(`Task "${task}" added successfully.`);
  }, 1000);
};

const listTasksCallback = (callback) => {
  setTimeout(() => {
    callback(tasks);
  }, 1000);
};

console.log(" Callback Version");

addTaskCallback("Learn JavaScript", (message) => {
  console.log(message);

  listTasksCallback((taskList) => {
    console.log(`Tasks: ${taskList.join(", ")}`);
  });
});

const addTaskPromise = (task) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks.push(task);
      resolve(`Task "${task}" added successfully.`);
    }, 1000);
  });
};

const deleteTaskPromise = (taskName) => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const index = tasks.indexOf(taskName);

      if (index === -1) {
        reject("Task not found.");
      } else {
        tasks.splice(index, 1);
        resolve(`Task "${taskName}" deleted successfully.`);
      }
    }, 1000);
  });
};

const listTasksPromise = () => {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(tasks);
    }, 1000);
  });
};

setTimeout(() => {
  console.log("\n Promise Version");

  addTaskPromise("Practice Promises")
    .then((msg) => {
      console.log(msg);
      return listTasksPromise();
    })
    .then((taskList) => {
      console.log(`Tasks: ${taskList.join(", ")}`);
      return deleteTaskPromise("Learn JavaScript");
    })
    .then((msg) => {
      console.log(msg);
      return listTasksPromise();
    })
    .then((taskList) => {
      console.log(`Updated Tasks: ${taskList.join(", ")}`);
    })
    .catch((error) => console.error(error));

}, 3000);


const addTaskAsync = async (task) => {
  return await addTaskPromise(task);
};

const deleteTaskAsync = async (taskName) => {
  return await deleteTaskPromise(taskName);
};

const listTasksAsync = async () => {
  return await listTasksPromise();
};

const runAsyncVersion = async () => {
  try {
    console.log("\n Async/Await Version");

    const addMsg = await addTaskAsync("Build Project");
    console.log(addMsg);

    const taskList = await listTasksAsync();
    console.log(`Tasks: ${taskList.join(", ")}`);

    const deleteMsg = await deleteTaskAsync("Build Project");
    console.log(deleteMsg);

    const updatedTasks = await listTasksAsync();
    console.log(`Updated Tasks: ${updatedTasks.join(", ")}`);

  } catch (error) {
    console.error(error);
  }
};

setTimeout(runAsyncVersion, 7000);