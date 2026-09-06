const sidebar = document.getElementById("sidebar");

if (sidebar) {

    if (sessionStorage.getItem("sidebarOpen") === "true") {
        sidebar.classList.add("sidebar-open");
    }

    sidebar.addEventListener("mouseenter", function () {
        sidebar.classList.add("sidebar-open");

        sessionStorage.setItem("sidebarOpen", "true");
    });

    sidebar.addEventListener("mouseleave", function () {
        sidebar.classList.remove("sidebar-open");

        sessionStorage.setItem("sidebarOpen", "false");
    });
}

const successAlert = document.querySelector(".success-alert");

if (successAlert) {
    setTimeout(function () {
        const alert = bootstrap.Alert.getOrCreateInstance(successAlert);

        alert.close();
    }, 3500);
}